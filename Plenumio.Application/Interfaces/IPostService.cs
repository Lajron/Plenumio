using Plenumio.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Interfaces {
    public interface IPostService {
        Task<PostDto> CreatePostAsync(CreatePostDto createPostDto);
        Task<PostDto> UpdatePostAsync(int postId, UpdatePostDto updatePostDto);
        Task<bool> DeletePostAsync(int postId);
        Task<bool> SoftDeletePostAsync(int postId);

        Task<PostDto?> GetPostByIdAsync(int postId);
        Task<PostDto?> GetPostBySlugAsync(string slug);
        Task<IEnumerable<PostDto>> GetPostsByUserIdAsync(int userId);
        Task<IEnumerable<PostDto>> GetPostsAsync();

        Task<IEnumerable<PostDto>> SearchPostsAsync(string query);
        Task<IEnumerable<PostDto>> GetPostsByTagAsync(int tagId);

        Task AddTagToPostAsync(int postId, int tagId);
        Task RemoveTagFromPostAsync(int postId, int tagId);

    }
}
