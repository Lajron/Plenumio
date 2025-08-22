using Plenumio.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plenumio.Infrastructure.Data;
using Plenumio.Contracts.DTOs;

namespace Plenumio.Application.Services {
    public class PostService(ApplicationDbContext db) : IPostService {
        

        public async Task<IEnumerable<PostDto>> GetPostsAsync() {
            throw new NotImplementedException();
        }

        public async Task<PostDto> CreatePostAsync(CreatePostDto createPostDto) {
            throw new NotImplementedException();
        }

        public async Task<PostDto> UpdatePostAsync(int postId, UpdatePostDto updatePostDto) {
            throw new NotImplementedException();
        }

        public async Task<bool> DeletePostAsync(int postId) {
            throw new NotImplementedException();
        }

        public async Task<bool> SoftDeletePostAsync(int postId) {
            throw new NotImplementedException();
        }

        public async Task<PostDto?> GetPostByIdAsync(int postId) {
            throw new NotImplementedException();
        }

        public async Task<PostDto?> GetPostBySlugAsync(string slug) {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PostDto>> GetPostsByTagAsync(int tagId) {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PostDto>> GetPostsByUserIdAsync(int userId) {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PostDto>> SearchPostsAsync(string query) {
            throw new NotImplementedException();
        }

        public async Task AddTagToPostAsync(int postId, int tagId) {
            throw new NotImplementedException();
        }

        public async Task RemoveTagFromPostAsync(int postId, int tagId) {
            throw new NotImplementedException();
        }

        

        

        
    }
}
