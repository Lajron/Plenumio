using Microsoft.EntityFrameworkCore;
using Plenumio.Application.DTOs;
using Plenumio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plenumio.Core.Entities;

using Plenumio.Application.Mapping;
using Plenumio.Application.DTOs.Comments;
using Plenumio.Application.DTOs.Comments.Requests;
using LinqKit;

namespace Plenumio.Application.Queries.CommentHandlers {
    public class GetCommentsForPostHandler(ApplicationDbContext db)
        : IQueryHandler<GetCommentsForPostRequest, IEnumerable<CommentDetailsDto>> {
        public async Task<IEnumerable<CommentDetailsDto>> HandleAsync(GetCommentsForPostRequest query, CancellationToken cancellationToken = default) {
            IQueryable<Comment> q = db.Comments
                .AsExpandable()
                .Where(c => c.PostId == query.PostId && c.ParentId == null)
                .OrderByDescending(c => c.CreatedAt)
                .ThenBy(c => c.Id);

            if (query.Top is not null)
                q = q.Take(query.Top.Value);

            return await q.Select(c => CommentMapper.ToDetailDto().Invoke(c))
                .ToListAsync(cancellationToken);
        }
    }
}
