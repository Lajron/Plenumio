using Plenumio.Application.DTOs;
using Plenumio.Application.DTOs.Comments;
using Plenumio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Interfaces {
    public interface ICommentService {
        Task<CommentIdSlugDto> CreateCommentAsync(CreateCommentDto request, Guid userId);
        Task<CommentDetailsDto?> CreateReplyAsync(CreateCommentDto request, Guid userId);
        Task<IEnumerable<CommentDetailsDto>> GetRepliesForComment(Guid parentId);
    }
}