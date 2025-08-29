using Plenumio.Application.DTOs;
using Plenumio.Application.Interfaces;
using Plenumio.Application.Queries;
using Plenumio.Application.Queries.Comment;
using Plenumio.Core.Entities;
using Plenumio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Services {
    public class CommentService(IUnitOfWork uof, IQueryDispatcher queryDispatcher)
        : ICommentService {
        public async Task<CommentIdSlugDto> CreateCommentAsync(CreateCommentDto request, Guid userId) {
            string postSlug = await uof.Posts.GetSlugById(request.PostId) ?? throw new ApplicationException("No post");
            
            Comment comment = new Comment {
                Content = request.Content,
                PostId = request.PostId,
                ApplicationUserId = userId,
                ParentId = request.ParentId
            };

            await uof.Comments.AddAsync(comment);
            await uof.CompleteAsync();

            return new CommentIdSlugDto(comment.Id, postSlug);
        }

        public async Task<CommentDto?> CreateReplyAsync(CreateCommentDto request, Guid userId) {
            Comment comment = new Comment {
                Content = request.Content,
                PostId = request.PostId,
                ApplicationUserId = userId,
                ParentId = request.ParentId
            };

            await uof.Comments.AddAsync(comment);
            await uof.CompleteAsync();

            GetCreatedReplyQuery query = new GetCreatedReplyQuery(comment.Id);
            return await queryDispatcher.SendAsync<GetCreatedReplyQuery, CommentDto>(query);
        }


        public async Task<IEnumerable<CommentDto>> GetRepliesForComment(Guid parentId) {
            GetRepliesFromCommentQuery query = new GetRepliesFromCommentQuery(parentId);

            return await queryDispatcher.SendAsync<GetRepliesFromCommentQuery, IEnumerable<CommentDto>>(query);
        }
    }
}
