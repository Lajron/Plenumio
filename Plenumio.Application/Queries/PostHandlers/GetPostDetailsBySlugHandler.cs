using LinqKit;
using Microsoft.EntityFrameworkCore;
using Plenumio.Application.DTOs;
using Plenumio.Application.Mapping;
using Plenumio.Core.Entities;
using Plenumio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Queries.PostHandlers {
    public class GetPostDetailsBySlugHandler(ApplicationDbContext db)
        : IQueryHandler<GetPostDetailsBySlugQuery, PostDto?> {
        public async Task<PostDto?> HandleAsync(GetPostDetailsBySlugQuery query, CancellationToken cancellationToken = default) {
            return await db.Posts
                .AsExpandable()
                .Where(p => p.Slug == query.Slug)
                .Select(p => new PostDto(
                    p.Id,
                    p.Title,
                    p.Content,
                    p.Slug,
                    p.Type,
                    p.Privacy,
                    p.CreatedAt,
                    p.UpdatedAt,
                    new OldUserSummaryDto(
                            p.ApplicationUser!.Id,
                            p.ApplicationUser.DisplayedName,
                            p.ApplicationUser.AvatarUrl,
                            p.ApplicationUser.IsVerified
                        ),
                    p.PostTag.Select(tp => TagMapper.ToSummaryDto().Invoke(tp.Tag!)),
                    p.Images.Select(img => new ImageDto(img.Id, img.Url)),
                    p.Comments
                            .OrderBy(c => c.CreatedAt)
                            .ThenBy(c => c.Id)
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
                                )
                        ),
                    p.Reactions
                        .Select(r => r.Type)
                        .Distinct()
                        .Select(t => new ReactionDto(t.ToString())),
                    p.Comments.Count,
                    p.Reactions.Count
                ))
                .AsSplitQuery()
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
