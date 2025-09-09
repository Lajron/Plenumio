using LinqKit;
using Microsoft.EntityFrameworkCore;
using Plenumio.Application.DTOs;
using Plenumio.Application.DTOs.Comments;
using Plenumio.Application.DTOs.Comments.Requests;
using Plenumio.Application.Mapping;
using Plenumio.Core.Entities;
using Plenumio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Queries.CommentHandlers {
    public class GetCreatedReplyHandler(ApplicationDbContext db) : IQueryHandler<GetByCommentIdRequest, CommentDetailsDto?> {
        public async Task<CommentDetailsDto?> HandleAsync(GetByCommentIdRequest query, CancellationToken cancellationToken = default) {
            return await db.Comments
                .AsExpandable()
                .Where(c => c.Id == query.CommentId)
                .Select(c => CommentMapper.ToDetailDto().Invoke(c))
                .SingleOrDefaultAsync(cancellationToken);
        }
    }
}
