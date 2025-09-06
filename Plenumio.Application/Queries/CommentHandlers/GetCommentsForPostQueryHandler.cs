using Microsoft.EntityFrameworkCore;
using Plenumio.Application.DTOs;
using Plenumio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plenumio.Core.Entities;

using CommentEntity = Plenumio.Core.Entities.Comment;

namespace Plenumio.Application.Queries.Comment {
    public class GetCommentsForPostQueryHandler(ApplicationDbContext db)
        : IQueryHandler<GetCommentsForPostQuery, IEnumerable<CommentDto>> {
        public async Task<IEnumerable<CommentDto>> HandleAsync(GetCommentsForPostQuery query, CancellationToken cancellationToken = default) {
            IQueryable<CommentEntity> q = db.Comments
                .Where(c => c.PostId == query.Id && c.ParentId == null)
                .OrderByDescending(c => c.CreatedAt)
                .ThenBy(c => c.Id);

            if (query.Top is not null)
                q = q.Take(query.Top.Value);

            return await q.Select(c => new CommentDto(
                    c.Id,
                    c.Content,
                    new OldUserSummaryDto(
                            c.ApplicationUser!.Id,
                            c.ApplicationUser.DisplayedName,
                            c.ApplicationUser.AvatarUrl,
                            c.ApplicationUser.IsVerified
                        ),
                    c.CreatedAt,
                    c.UpdatedAt,
                    c.Children.Any(),
                    c.PostId,
                    c.ParentId
                    ))
                .ToListAsync(cancellationToken);
        }
    }
}
