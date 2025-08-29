using Microsoft.EntityFrameworkCore;
using Plenumio.Application.DTOs;
using Plenumio.Core.Entities;
using Plenumio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Queries.Feed {
    public class GetPostsForFeedQueryHandler(ApplicationDbContext db)
        : IQueryHandler<GetPostsForFeedQuery, IEnumerable<PostFeedDto>> {
        public async Task<IEnumerable<PostFeedDto>> HandleAsync(GetPostsForFeedQuery query, CancellationToken cancellationToken = default) {
            int skipAmount = (query.PageNumber - 1) * query.PageSize;
            //God help me
            return await db.Posts
                .OrderByDescending(p => p.CreatedAt)
                .ThenBy(p => p.Id)
                .Skip(skipAmount)
                .Take(query.PageSize)
                .Select(p => new PostFeedDto (
                    p.Id,
                    p.Title,
                    p.Content,
                    p.Slug,
                    p.Type,
                    p.CreatedAt,
                    p.UpdatedAt,
                    new UserSummaryDto(
                            p.ApplicationUser!.Id,
                            p.ApplicationUser.DisplayedName,
                            p.ApplicationUser.AvatarUrl,
                            p.ApplicationUser.IsVerified
                        ),
                    p.PostTag.Select(tp => new TagDto(tp.Tag!.Id, tp.Tag.Name, tp.Tag.DisplayedName)),
                    p.Images.Select(img => new ImageDto(img.Id, img.Url)),
                    p.Reactions.Count,
                    p.Comments.Count
                ))
                .AsSplitQuery()
                .ToListAsync(cancellationToken);

        }
    }
}
