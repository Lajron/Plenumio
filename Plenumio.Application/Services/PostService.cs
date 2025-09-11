using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Plenumio.Application.DTOs;
using Plenumio.Application.DTOs.Comments;
using Plenumio.Application.DTOs.Comments.Requests;
using Plenumio.Application.DTOs.Posts;
using Plenumio.Application.DTOs.Posts.Requests;
using Plenumio.Application.DTOs.Posts.Responses;
using Plenumio.Application.Interfaces;
using Plenumio.Application.Queries;
using Plenumio.Application.Queries.PostHandlers;
using Plenumio.Application.Utilities;
using Plenumio.Application.Validation;
using Plenumio.Core.Entities;
using Plenumio.Core.Enums;
using Plenumio.Core.Exceptions;
using Plenumio.Core.Interfaces;
using Plenumio.Infrastructure.Data;
using Plenumio.Infrastructure.Persistance;
using Plenumio.Infrastructure.Services;
using Plenumio.Infrastructure.Specifications;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Plenumio.Application.Services {
    public class PostService(IUnitOfWork uof, IQueryDispatcher queryDispatcher, IImageService imageService) 
        : IPostService {
        public async Task<CreatePostResponse> CreatePostAsync(CreatePostRequest request, Guid userId, IEnumerable<ImageFileDto> imgFiles) {
            request.ValidateCreatePost();

            var imageFolder = $"users/{userId}/posts";
            IEnumerable<string> storedImageUrls = [];

            Guid postId = Guid.Empty;
            string postSlug = string.Empty;

            await uof.ExecuteInTransactionAsync(
                trySection: async () => {
                    postSlug = SlugGenerator.GeneratePostSlug(request.Content, request.Title);
                    var post = new Post {
                        Title = request.Title,
                        Content = request.Content,
                        Slug = postSlug,
                        Type = request.Type,
                        Privacy = request.Privacy,
                        ApplicationUserId = userId,
                        Images = []
                    };

                    var tagMap = request.Tags
                        .Select(t => t.TrimStart('#').Trim())
                        .GroupBy(t => SlugGenerator.GenerateTagSlug(t))
                        .ToDictionary(g => g.Key, g => g.First());
                    post.PostTag = await uof.Tags.ResolveTagsAsync(tagMap);

                    await uof.Posts.AddAsync(post);
                    await uof.CompleteAsync();

                    postId = post.Id;

                    if (imgFiles.Any()) {
                        storedImageUrls = await imageService.SaveImagesAsync(imgFiles, $"users/{userId}/posts/{post.Id}");
                        post.Images = storedImageUrls.Select(url => new PostImage { Url = url }).ToImmutableList();
                    }

                    await uof.CompleteAsync();
                },
                catchSection: async (e) => {

                    if (storedImageUrls.Any()) {
                        await imageService.DeleteImagesAsync(storedImageUrls);
                    }

                    if (e is DbUpdateException) {
                        throw new ConflictException("Failed to create post due to a persistence conflict.");
                    }

                    throw new ValidationException("Post creation failed.");
                }
            );
            return new CreatePostResponse {
                Id = postId,
                Slug = postSlug
            };
        }

        public async Task<GetPostsResponse> GetPostsAsync(PostFilterDto filters, Guid? currentUserId) {
            var query = new GetPostsRequest {
                Filters = filters,
                UserId = currentUserId
            };

            return await queryDispatcher.SendAsync<GetPostsRequest, GetPostsResponse>(query);

        }
        public async Task<IEnumerable<CommentDetailsDto>> GetPostCommentsAsync(Guid id, int? top = null) {
            var query = new GetCommentsForPostRequest {
                PostId = id,
                Top = top
            };

            return await queryDispatcher.SendAsync<GetCommentsForPostRequest, IEnumerable<CommentDetailsDto>>(query);
        }

        public async Task<PostDetailsDto?> GetPostBySlugAsync(string slug, Guid? currentUserId) {
            var query = new GetPostDetailsBySlugRequest {
                Slug = slug,
                ViewerUserId = currentUserId
            };
            return await queryDispatcher.SendAsync<GetPostDetailsBySlugRequest, PostDetailsDto>(query);
        }

        public async Task<string?> GetPostSlugByIdAsync(Guid id) {
            return await uof.Posts.GetSlugById(id);
        }

        public async Task UpdatePostAsync(UpdatePostRequest request, Guid userId) {
            var postUpdateSpec = new PostUpdateSpecification(
                request.Id, 
                userId,
                request.ImagesToRemove.Any() || request.NewImagesToUpload.Any(),
                request.TagsToRemove.Any() || request.TagsToAdd.Any()
            );

            var post = await uof.Posts.FindAsync(postUpdateSpec)
                ?? throw new NotFoundException("Post not found or you do not have permission to update it.");
            
            var imageFolder = $"users/{userId}/posts/{post.Id}";
            IEnumerable<string> newlyStoredImageUrls = [];

            await uof.ExecuteInTransactionAsync(
                trySection: async () => {
                    if (request.NewTitle is not null && request.NewTitle != post.Title) {
                        post.Title = request.NewTitle;
                    }
                    if (request.NewContent is not null && request.NewContent != post.Content) {
                        post.Content = request.NewContent;
                    }

                    if (request.Privacy is not null && request.Privacy != post.Privacy) {
                        post.Privacy = request.Privacy.Value;
                    }

                    if (request.TagsToRemove.Any())
                        post.PostTag = post.PostTag
                            .Where(pt => !request.TagsToRemove.Contains(pt.TagId))
                            .ToList();

                    if (request.TagsToAdd.Any()) {
                        var tagMap = request.TagsToAdd
                            .Select(t => t.TrimStart('#').Trim())
                            .GroupBy(t => SlugGenerator.GenerateTagSlug(t))
                            .ToDictionary(g => g.Key, g => g.First());
                        post.PostTag = await uof.Tags.ResolveTagsAsync(tagMap);
                    }
                    },
                catchSection: async (e) => {
                    if (newlyStoredImageUrls.Any()) {
                        await imageService.DeleteImagesAsync(newlyStoredImageUrls);
                    }
                    if (e is DbUpdateException) {
                        throw new ConflictException("Failed to update post due to a persistence conflict.");
                    }
                    throw new ValidationException("Post update failed.");
                }
            );



    }
}
