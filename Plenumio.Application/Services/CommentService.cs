using Plenumio.Application.DTOs;
using Plenumio.Application.DTOs.Comments;
using Plenumio.Application.DTOs.Comments.Requests;
using Plenumio.Application.Interfaces;
using Plenumio.Application.Queries;
using Plenumio.Application.Validation;
using Plenumio.Core.Entities;
using Plenumio.Core.Exceptions;
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
            request.ValidateCreateComment();

            string postSlug = await uof.Posts.GetSlugById(request.PostId)
                ?? throw new NotFoundException("Post not found.", "Post", request.PostId);

            var comment = new Comment {
                Content = request.Content.Trim(),
                PostId = request.PostId,
                ApplicationUserId = userId,
                ParentId = null
            };

            await uof.Comments.AddAsync(comment);
            await uof.CompleteAsync();

            return new CommentIdSlugDto(comment.Id, postSlug);
        }

        public async Task<CommentDetailsDto?> CreateReplyAsync(CreateCommentDto request, Guid userId) {
            request.ValidateCreateReply();

            _ = await uof.Posts.GetSlugById(request.PostId)
                ?? throw new NotFoundException("Post not found.", "Post", request.PostId);

            var comment = new Comment {
                Content = request.Content.Trim(),
                PostId = request.PostId,
                ApplicationUserId = userId,
                ParentId = request.ParentId
            };

            await uof.Comments.AddAsync(comment);
            await uof.CompleteAsync();

            var query = new GetByCommentIdRequest {
                CommentId = comment.Id
            };
            return await queryDispatcher.SendAsync<GetByCommentIdRequest, CommentDetailsDto>(query);
        }


        public async Task<IEnumerable<CommentDetailsDto>> GetRepliesForComment(Guid parentId) {
            var query = new GetByCommentIdRequest {
                CommentId = parentId
            };

            return await queryDispatcher.SendAsync<GetByCommentIdRequest, IEnumerable<CommentDetailsDto>>(query);
        }
    }
}
