using Plenumio.Application.DTOs;
using Plenumio.Application.DTOs.Posts;
using Plenumio.Application.DTOs.Posts.Requests;
using Plenumio.Application.DTOs.Posts.Responses;
using Plenumio.Application.Queries;
using Plenumio.Application.Queries.PostHandlers;
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
        Task<CreatePostResponse> CreatePostAsync(CreatePostRequest createPostDto, Guid userId, IEnumerable<ImageFileDto> imgFiles);
        Task<GetPostsResponse> GetPostsAsync(PostFilterDto filters, Guid? currentUserId);
        Task<IEnumerable<CommentDto>> GetPostCommentsAsync(Guid id, int? top = null);
        Task<PostDto?> GetPostBySlugAsync(string slug);
        Task<string?> GetPostSlugByIdAsync(Guid id);
    }
}
