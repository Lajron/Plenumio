using Microsoft.EntityFrameworkCore;
using Plenumio.Application.DTOs.Users.Requests;
using Plenumio.Application.DTOs.Users.Responses;
using Plenumio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Queries.UserHandlers {
    public class GetUserProfileHandler(
        ApplicationDbContext db
        ) : IQueryHandler<GetUserProfileRequest, GetUserProfileResponse?> {
        public async Task<GetUserProfileResponse?> HandleAsync(GetUserProfileRequest query, CancellationToken cancellationToken = default) {
            return await db.ApplicationUsers
                .Where(u => u.UserName == query.Username.ToUpper())
                .Select(u => new GetUserProfileResponse {
                    Id = u.Id,
                    DisplayedName = u.DisplayedName,
                    Username = u.UserName!,
                    Description = u.Description,
                    AvatarUrl = u.AvatarUrl,
                    BackgroundUrl = u.BackgroundUrl,
                    Website = u.Website,
                    IsVerified = u.IsVerified,
                    FollowersCount = u.Followers.Count,
                    FollowingCount = u.Following.Count,
                    PostsCount = u.Posts.Count,
                    IsFollowing = u.Followers.Any(f => f.FollowerId == query.CurrentUserId)
                    }
                )
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
