using Plenumio.Application.DTOs;
using Plenumio.Application.Queries;
using Plenumio.Application.Queries.Feed;
using Plenumio.Application.Queries.Post;
using Plenumio.Application.Services;
using Plenumio.Core.Enums;
using Plenumio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Interfaces {
    public interface IPostService {
        Task<PostIdSlugDto> CreatePostAsync(CreatePostDto createPostDto, Guid userId, IEnumerable<ImageFileDto> imgFiles);
        Task<IEnumerable<PostFeedDto>> GetFeedPostsAsync();

        Task<PostsQueryResult> GetPostsAsync(FeedFilterQuery filters, Guid? currentUserId);

        Task<IEnumerable<CommentDto>> GetPostCommentsAsync(Guid id, int? top = null);

        Task<PostDto?> GetPostBySlugAsync(string slug);
        Task<string?> GetPostSlugById(Guid id);
    }
}
