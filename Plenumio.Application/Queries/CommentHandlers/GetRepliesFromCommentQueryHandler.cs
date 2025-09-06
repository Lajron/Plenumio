using Microsoft.EntityFrameworkCore;
using Plenumio.Application.DTOs;
using Plenumio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Queries.Comment {
    public class GetRepliesFromCommentQueryHandler(ApplicationDbContext db) : IQueryHandler<GetRepliesFromCommentQuery, IEnumerable<CommentDto>>{
        public async Task<IEnumerable<CommentDto>> HandleAsync(GetRepliesFromCommentQuery query, CancellationToken cancellationToken = default) {
            return await db.Comments
                .Where(c => c.ParentId == query.CommentId)
                .OrderBy(c => c.CreatedAt)
                .Select(c => new CommentDto(
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
