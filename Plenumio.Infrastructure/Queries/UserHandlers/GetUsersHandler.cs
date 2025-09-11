using LinqKit;
using Microsoft.EntityFrameworkCore;
using Plenumio.Application.DTOs.Tags.Requests;
using Plenumio.Application.DTOs.Tags.Responses;
using Plenumio.Application.DTOs.Users;
using Plenumio.Application.DTOs.Users.Requests;
using Plenumio.Application.Interfaces;
using Plenumio.Application.Mapping;
using Plenumio.Core.Entities;
using Plenumio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Infrastructure.Queries.UserHandlers {
    public class GetUsersHandler(
            ApplicationDbContext db,
            ISortStrategy<ApplicationUser> sortStrategy,
            ISlugGenerator slugGenerator
        ) : IQueryHandler<GetUsersRequest, IEnumerable<UserSummaryDto>> {
        public async Task<IEnumerable<UserSummaryDto>> HandleAsync(GetUsersRequest query, CancellationToken cancellationToken = default) {
            var userQuery = db.ApplicationUser.AsQueryable();

            if (query.Filters.FromDate.HasValue) {
                userQuery = userQuery.Where(p => p.CreatedAt >= query.Filters.FromDate.Value);
            }

            if (query.Filters.ToDate.HasValue) {
                userQuery = userQuery.Where(p => p.CreatedAt <= query.Filters.ToDate.Value);
            }

            var search = query.Filters.SearchTerm?.Trim();
            if (!string.IsNullOrEmpty(search)) {
                var slugSearch = slugGenerator.GenerateTagSlug(search);
                userQuery = userQuery.Where(u =>
                    u.NormalizedUserName!.Contains(slugSearch) ||
                    u.DisplayedName.Contains(search)
                );
            }

            userQuery = sortStrategy.ApplySort(userQuery, query.Filters.Sort);

            return await userQuery
                .AsExpandable()
                .Skip((query.Filters.Page - 1) * query.Filters.PageSize)
                .Take(query.Filters.PageSize)
                .Select(u => UserMapper.ToSummaryDto().Invoke(u))
                .ToListAsync(cancellationToken);
        }
    }
}
