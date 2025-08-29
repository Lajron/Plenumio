using Microsoft.AspNetCore.Identity;
using Plenumio.Application.DTOs;
using Plenumio.Application.Interfaces;
using Plenumio.Application.Queries;
using Plenumio.Application.Queries.Comment;
using Plenumio.Application.Queries.Feed;
using Plenumio.Application.Queries.Post;
using Plenumio.Application.Utilities;
using Plenumio.Core.Entities;
using Plenumio.Core.Enums;
using Plenumio.Core.Interfaces;
using Plenumio.Infrastructure.Data;
using Plenumio.Infrastructure.Persistance;
using Plenumio.Infrastructure.Services;
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
        public async Task<PostIdSlugDto> CreatePostAsync(CreatePostDto request, Guid userId, IEnumerable<ImageFileDto> imgFiles) {
            Guid postId = Guid.Empty;
            string postSlug = string.Empty;
            IEnumerable<string> storedImageUrls = [];

            await uof.ExecuteInTransactionAsync(
                trySection: async () => {

                    Post post = new Post {
                        Title = request.Title,
                        Content = request.Content,
                        Slug = string.Empty,
                        Type = request.Type,
                        Privacy = request.Privacy,
                        ApplicationUserId = userId,
                        Images = []
                    };

                    post.Slug = SlugGenerator.GeneratePostSlug(request.Content, request.Title);

                    Dictionary<string, string> tagsWithSlug = request.Tags.ToDictionary(t => SlugGenerator.GenerateTagSlug(t), t => t);
                    post.PostTag = await uof.Tags.ResolveTagsAsync(tagsWithSlug);

                    await uof.Posts.AddAsync(post);
                    await uof.CompleteAsync();

                    postId = post.Id;
                    postSlug = post.Slug;

                    if (imgFiles.Any()) {
                        storedImageUrls = await imageService.SaveImagesAsync(imgFiles, userId.ToString() + "/" + post.Id.ToString());
                        post.Images = storedImageUrls.Select(url => new PostImage { Url = url }).ToList();
                    }

                    await uof.CompleteAsync();
                },
                catchSection: async (e) => {

                    if (imgFiles.Any()) {
                        await imageService.DeleteImagesAsync(storedImageUrls);
                    }
                    throw new ApplicationException("Failed to create post with images", e);
                }
            );
            return new PostIdSlugDto(postId, postSlug);
        }

        public async Task<IEnumerable<PostFeedDto>> GetFeedPostsAsync() {
            GetPostsForFeedQuery query = new GetPostsForFeedQuery(1, 10);

            return await queryDispatcher.SendAsync<GetPostsForFeedQuery, IEnumerable<PostFeedDto>>(query);
        }

        public async Task<IEnumerable<CommentDto>> GetPostCommentsAsync(Guid id, int? top = null) {
            GetCommentsForPostQuery query = new GetCommentsForPostQuery(id, top);

            return await queryDispatcher
                .SendAsync<GetCommentsForPostQuery, IEnumerable<CommentDto>>(query);
        }

        public async Task<PostDto?> GetPostBySlugAsync(string slug) {
            GetPostDetailsBySlugQuery query = new GetPostDetailsBySlugQuery(slug);

            return await queryDispatcher
                .SendAsync<GetPostDetailsBySlugQuery,  PostDto>(query);
        }





        //public async Task<IEnumerable<PostDto>> GetPostsAsync() {
        //    throw new NotImplementedException();
        //}



        //public async Task<PostDto> UpdatePostAsync(int postId, UpdatePostDto updatePostDto) {
        //    throw new NotImplementedException();
        //}

        //public async Task<bool> DeletePostAsync(int postId) {
        //    throw new NotImplementedException();
        //}

        //public async Task<bool> SoftDeletePostAsync(int postId) {
        //    throw new NotImplementedException();
        //}

        //public async Task<PostDto?> GetPostByIdAsync(int postId) {
        //    throw new NotImplementedException();
        //}

        //public async Task<PostDto?> GetPostBySlugAsync(string slug) {
        //    throw new NotImplementedException();
        //}

        //public async Task<IEnumerable<PostDto>> GetPostsByTagAsync(int tagId) {
        //    throw new NotImplementedException();
        //}

        //public async Task<IEnumerable<PostDto>> GetPostsByUserIdAsync(int userId) {
        //    throw new NotImplementedException();
        //}

        //public async Task<IEnumerable<PostDto>> SearchPostsAsync(string query) {
        //    throw new NotImplementedException();
        //}

        //public async Task AddTagToPostAsync(int postId, int tagId) {
        //    throw new NotImplementedException();
        //}

        //public async Task RemoveTagFromPostAsync(int postId, int tagId) {
        //    throw new NotImplementedException();
        //}






    }
}
