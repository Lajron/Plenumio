using Azure;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Plenumio.Application.DTOs.Tags.Requests;
using Plenumio.Application.DTOs.Tags.Responses;
using Plenumio.Application.Interfaces;
using Plenumio.Application.Mapping;
using Plenumio.Core.Entities;
using Plenumio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Infrastructure.Queries.TagHandlers {
    public class GetTagHandler(
        ApplicationDbContext db
        ) : IQueryHandler<GetTagRequest, GetTagResponse?> {
        public async Task<GetTagResponse?> HandleAsync(GetTagRequest query, CancellationToken cancellationToken = default) {
            return await db.Tags
                .AsExpandable()
                .Where(t => t.Name == query.Name)
                .Select(t => new GetTagResponse {
                    Id = t.Id,
                    Name = t.Name,
                    DisplayedName = t.DisplayedName,
                    PostsCount = t.PostTag.Count,
                    FollowersCount = t .UserTags.Count,
                    IsFollowing = t.UserTags.Any(ut => ut.ApplicationUserId == query.UserId),
                    Parent = t .Parent != null ? TagMapper.ToSummaryDto().Invoke(t.Parent) : null,
                    Children = t.Children.Select(tc => TagMapper.ToSummaryDto().Invoke(tc))
                })
                .AsSplitQuery()
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
