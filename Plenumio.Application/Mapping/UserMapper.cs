using Plenumio.Application.DTOs.Users;
using Plenumio.Application.DTOs.Users.Responses;
using Plenumio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Mapping {
    public static class UserMapper {
        public static Expression<Func<ApplicationUser, UserSummaryDto>> ToSummaryDto() {
            return user => new UserSummaryDto {
                Id = user.Id,
                DisplayedName = user.DisplayedName,
                Username = user.UserName!,
                AvatarUrl = user.AvatarUrl,
                IsVerified = user.IsVerified
            };
        }

        public static Expression<Func<ApplicationUser, Guid?, GetUserProfileResponse>> ToProfileDto() {
            return (user, currentUserId) => new GetUserProfileResponse {
                Id = user.Id,
                DisplayedName = user.DisplayedName,
                Username = user.UserName!,
                Description = user.Description,
                AvatarUrl = user.AvatarUrl,
                BackgroundUrl = user.BackgroundUrl,
                Website = user.Website,
                IsVerified = user.IsVerified,
                FollowersCount = user.Followers.Count,
                FollowingCount = user.Following.Count,
                PostsCount = user.Posts.Count,
                IsFollowing = user.Followers.Any(f => f.FollowerId == currentUserId)
            };
        }
    }
}
