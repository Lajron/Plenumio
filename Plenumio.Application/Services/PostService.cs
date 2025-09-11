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
using Plenumio.Application.Specifications.Posts;
using Plenumio.Application.Validation;
using Plenumio.Core.Entities;
using Plenumio.Core.Enums;
using Plenumio.Core.Exceptions;
using Plenumio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Plenumio.Application.Services {
    public class PostService(
            IUnitOfWork uof, 
            IQueryDispatcher queryDispatcher, 
            IImageService imageService,
            ISlugGenerator slugGenerator
        ) : IPostService {
        public async Task<CreatePostResponse> CreatePostAsync(CreatePostRequest request, Guid userId, IEnumerable<ImageFileDto> imgFiles) {
            request.ValidateCreatePost();

            var imageFolder = $"users/{userId}/posts";
            IEnumerable<string> storedImageUrls = [];

            Guid postId = Guid.Empty;
            string postSlug = string.Empty;

            await uof.ExecuteInTransactionAsync(
                trySection: async () => {
                    postSlug = slugGenerator.GeneratePostSlug(request.Content, request.Title);
                    var post = new Post {
                        Title = request.Title,
                        Content = request.Content,
                        Slug = postSlug,
                        Type = request.Type,
                        Privacy = request.Privacy,
                        ApplicationUserId = userId,
                        Images = []
                    };

                    
                    post.PostTag = await uof.Tags.ResolveTagsAsync(request.Tags);

                    if (imgFiles.Any()) {
                        storedImageUrls = await imageService.SaveImagesAsync(imgFiles, $"users/{userId}/posts/{post.Slug}");
                        post.Images = storedImageUrls.Select(url => new PostImage { Url = url }).ToImmutableList();
                    }

                    await uof.Posts.AddAsync(post);
                    await uof.CompleteAsync();

                    postId = post.Id;
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

                    // Remove tags (PostTag is the join entity)
                    if (request.TagsToRemove.Any()) {
                        var toRemove = post.PostTag
                            .Where(pt => request.TagsToRemove.Contains(pt.TagId))
                            .ToList();

                        foreach (var pt in toRemove)
                            post.PostTag.Remove(pt); // marks pt as Deleted when tracked
                    }

                    // Add tags (avoid duplicates)
                    if (request.TagsToAdd.Any()) {
                        var newTags = await uof.Tags.ResolveTagsAsync(request.TagsToAdd);
                        // If ResolveTagsAsync returns PostTag rows, filter out ones already present
                        var existingTagIds = post.PostTag.Select(pt => pt.TagId).ToHashSet();
                        var toAdd = newTags.Where(pt => !existingTagIds.Contains(pt.TagId)).ToList();
                        if (toAdd.Count > 0)
                            post.PostTag = post.PostTag.Concat(toAdd).ToList();
                    }

                    // Remove images (child entities)
                    if (request.ImagesToRemove.Any()) {
                        var imgsToRemove = post.Images
                            .Where(img => request.ImagesToRemove.Contains(img.Id))
                            .ToList();

                        foreach (var img in imgsToRemove)
                            post.Images.Remove(img); // marks image as Deleted when tracked

                        // Optional: also delete files from storage
                        // await imageService.DeleteImagesAsync(imgsToRemove.Select(i => i.Url));
                    }

                    if (request.NewImagesToUpload.Any()) {
                        newlyStoredImageUrls = await imageService.SaveImagesAsync(request.NewImagesToUpload, imageFolder);
                        var newPostImages = newlyStoredImageUrls.Select(url => new PostImage { Url = url }).ToList();
                        post.Images = post.Images.Concat(newPostImages).ToList();
                    }

                    await uof.CompleteAsync();
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
}
