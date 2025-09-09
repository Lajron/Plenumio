using LinqKit;
using Microsoft.EntityFrameworkCore;
using Plenumio.Application.DTOs;
using Plenumio.Application.DTOs.Comments;
using Plenumio.Application.DTOs.Comments.Requests;
using Plenumio.Application.Mapping;
using Plenumio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Queries.CommentHandlers {
    public class GetRepliesFromCommentHandler(ApplicationDbContext db) : IQueryHandler<GetByCommentIdRequest, IEnumerable<CommentDetailsDto>>{
        public async Task<IEnumerable<CommentDetailsDto>> HandleAsync(GetByCommentIdRequest query, CancellationToken cancellationToken = default) {
            return await db.Comments
                .AsExpandable()
                .Where(c => c.ParentId == query.CommentId)
                .OrderBy(c => c.CreatedAt)
                .Select(c => CommentMapper.ToDetailDto().Invoke(c))
                .ToListAsync(cancellationToken);
        }
    }
}
