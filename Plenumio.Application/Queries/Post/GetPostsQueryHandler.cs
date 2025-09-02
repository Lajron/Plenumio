using Microsoft.EntityFrameworkCore;
using Plenumio.Application.DTOs;
using Plenumio.Application.Extensions;
using Plenumio.Application.Interfaces;
using Plenumio.Core.Enums;
using Plenumio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PostEntity = Plenumio.Core.Entities.Post;

namespace Plenumio.Application.Queries.Post {
    public class GetPostsQueryHandler(
            ApplicationDbContext db,
            ISortStrategy<PostEntity> sortStrategy
        ) 
        : IQueryHandler<GetPostsQuery, PostsQueryResult> {

        public async Task<PostsQueryResult> HandleAsync(GetPostsQuery query, CancellationToken cancellationToken = default) {

            var postsQuery = db.Posts.AsQueryable();

            // Move this later to factory pattern
            switch (query.Filters.Scope) {
                case FeedScope.Global:
                    postsQuery = postsQuery.ForGlobalFeed(query.UserId);
                    break;
                case FeedScope.Personal:
                    var followingIds = await db.Follows.Where(f => f.FollowerId == query.UserId && !f.IsDeleted).Select(f => f.FollowedId).ToListAsync(cancellationToken);
                    var followedTagIds = await db.ApplicaitonUserTag.Where(ut => ut.ApplicationUserId == query.UserId).Select(ut => ut.TagId).ToListAsync(cancellationToken);
                    postsQuery = postsQuery.ForPersonalFeed(query.UserId!.Value, followingIds, followedTagIds);
                    break;
                default:
                    postsQuery = postsQuery.ForGlobalFeed(query.UserId);
                    break;
            }

            if (!string.IsNullOrEmpty(query.Filters.Search)) {
                postsQuery = postsQuery.Where(p =>
                    p.Title.Contains(query.Filters.Search) ||
                    p.Content.Contains(query.Filters.Search));
            }

            if (!string.IsNullOrEmpty(query.Filters.Tag)) {
                var tag = await db.Tags
                    .AsNoTracking()
                    .FirstOrDefaultAsync(t => t.Name == query.Filters.Tag, cancellationToken);

                postsQuery = postsQuery.WhereTag(tag);
            }

            if (query.Filters.PostType is not null) {
                postsQuery = postsQuery.Where(p => p.Type == query.Filters.PostType);
            }

            if (query.Filters.FromDate.HasValue) {
                postsQuery = postsQuery.Where(p => p.CreatedAt >= query.Filters.FromDate.Value);
            }

            if (query.Filters.ToDate.HasValue) {
                postsQuery = postsQuery.Where(p => p.CreatedAt <= query.Filters.ToDate.Value);
            }

            if (query.Filters.Scope == FeedScope.Personal) {
                postsQuery = postsQuery.Distinct();
            }


            postsQuery = sortStrategy.ApplySort(postsQuery, query.Filters.Sort);

            var totalCount = await postsQuery.CountAsync(cancellationToken);

            var posts = await postsQuery
                .Skip((query.Filters.Page - 1) * query.Filters.PageSize)
                .Take(query.Filters.PageSize)
                .Select(p => new PostFeedDto(
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

            return new PostsQueryResult(posts, totalCount);
        }
    }
}
