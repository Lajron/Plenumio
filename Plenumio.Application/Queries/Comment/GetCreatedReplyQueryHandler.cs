using Microsoft.EntityFrameworkCore;
using Plenumio.Application.DTOs;
using Plenumio.Core.Entities;
using Plenumio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Queries.Comment {
    public class GetCreatedReplyQueryHandler(ApplicationDbContext db) : IQueryHandler<GetCreatedReplyQuery, CommentDto?> {
        public async Task<CommentDto?> HandleAsync(GetCreatedReplyQuery query, CancellationToken cancellationToken = default) {
            return await db.Comments
                .Where(c => c.Id == query.CommentId)
                .Select(c => new CommentDto(
                    c.Id,
                    c.Content,
                    new UserSummaryDto(
                        c.ApplicationUserId,
                        c.ApplicationUser!.DisplayedName,
                        c.ApplicationUser.AvatarUrl,
                        c.ApplicationUser.IsVerified
                        ),
                    c.CreatedAt,
                    c.UpdatedAt,
                    c.Children.Any(),
                    c.PostId,
                    c.ParentId
                    )
                ).SingleOrDefaultAsync(cancellationToken);
        }
    }
}
