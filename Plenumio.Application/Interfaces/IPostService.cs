using Plenumio.Application.DTOs;
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
        Task<IEnumerable<CommentDto>> GetPostCommentsAsync(Guid id, int? top = null);
        Task<PostDto?> GetPostBySlugAsync(string slug);
    }
}
