using Microsoft.EntityFrameworkCore;
using Plenumio.Application.DTOs.Tags;
using Plenumio.Application.DTOs.Tags.Requests;
using Plenumio.Application.DTOs.Tags.Responses;
using Plenumio.Application.Interfaces;
using Plenumio.Application.Mapping;
using Plenumio.Application.Utilities;
using Plenumio.Core.Entities;
using Plenumio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Queries.TagHandlers {
    public class GetTagsHandler(
            ApplicationDbContext db,
            ISortStrategy<Tag> sortStrategy
        ) : IQueryHandler<GetTagsRequest, IEnumerable<GetTagResponse>> {
        public async Task<IEnumerable<GetTagResponse>> HandleAsync(GetTagsRequest query, CancellationToken cancellationToken = default) {
            var tagQuery = db.Tags.AsQueryable();

            if (query.Filters.FromDate.HasValue) {
                tagQuery = tagQuery.Where(p => p.CreatedAt >= query.Filters.FromDate.Value);
            }

            if (query.Filters.ToDate.HasValue) {
                tagQuery = tagQuery.Where(p => p.CreatedAt <= query.Filters.ToDate.Value);
            }

            if (query.Filters.UserId.HasValue) {
                tagQuery = tagQuery.Where(t => t.UserTags.Any(ut => ut.ApplicationUserId == query.Filters.UserId));
            }

            var search = query.Filters.SearchTerm?.Trim();
            if (!string.IsNullOrEmpty(search)) {
                var slugSearch = SlugGenerator.GenerateTagSlug(search);
                tagQuery = tagQuery.Where(t =>
                    t.Name.Contains(slugSearch) ||
                    t.DisplayedName.Contains(search)
                );
            }

            tagQuery = sortStrategy.ApplySort(tagQuery, query.Filters.Sort);

            return await tagQuery
                .Skip((query.Filters.Page - 1) * query.Filters.PageSize)
                .Take(query.Filters.PageSize)
                .Select(t => new GetTagResponse {
                    Id = t.Id,
                    Name = t.Name,
                    DisplayedName = t.DisplayedName,
                    PostsCount = t.PostTag.Count,
                    FollowersCount = t.UserTags.Count,
                    IsFollowing = t.UserTags.Any(ut => ut.ApplicationUserId == query.UserId)
                })
                .ToListAsync(cancellationToken);
        }
    }
}
