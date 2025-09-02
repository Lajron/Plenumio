using Microsoft.EntityFrameworkCore;
using Plenumio.Application.DTOs;
using Plenumio.Application.Queries.Feed;
using Plenumio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plenumio.Core.Entities;
using System.ComponentModel;

using TagEntity = Plenumio.Core.Entities.Tag;

namespace Plenumio.Application.Queries.Tag {
    public class GetPostsByTagQueryHandler(ApplicationDbContext db)
        : IQueryHandler<GetPostsByTagQuery, IEnumerable<PostFeedDto>> {
        public async Task<IEnumerable<PostFeedDto>> HandleAsync(GetPostsByTagQuery query, CancellationToken cancellationToken = default) {
            TagEntity? tag = await db.Tags.AsNoTracking().Where(t => t.Name == query.Name).FirstOrDefaultAsync(cancellationToken);
            
            if (tag is null) return [];

            IQueryable<PostTag> q = db.PostTag.Where(pt => pt.TagId == tag.Id);

            if (tag.ParentId is not null) {
                q = q.Concat(db.PostTag.Where(pt => pt.TagId == tag.ParentId))
                    .DistinctBy(pt => pt.PostId);
            }

            return await q
                .Select(pt => pt.Post)
                .Select(p => new PostFeedDto(
                    p!.Id,
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
                    )
                )
                .AsSplitQuery()
                .ToListAsync(cancellationToken);
        }
    }
}
