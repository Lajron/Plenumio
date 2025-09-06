using Plenumio.Application.DTOs.Users;
using Plenumio.Application.DTOs.Users.Responses;
using Plenumio.Web.Models.Profile;

namespace Plenumio.Web.Mapping {
    public static class UserMapper {
        public static UserVM ToVM(this GetUserProfileResponse dto) {
            return new UserVM {
                Id = dto.Id,
                DisplayedName = dto.DisplayedName,
                Username = dto.Username,
                Description = dto.Description,
                AvatarUrl = dto.AvatarUrl,
                BackgroundUrl = dto.BackgroundUrl,
                Website = dto.Website,
                IsVerified = dto.IsVerified,
                FollowersCount = dto.FollowersCount,
                FollowingCount = dto.FollowingCount,
                PostsCount = dto.PostsCount,
                IsFollowing = dto.IsFollowing
            };
        }

        public static UserSummaryVM ToVM(this UserSummaryDto dto) =>
        new() {
            Id = dto.Id,
            DisplayedName = dto.DisplayedName,
            Username = dto.Username,
            AvatarUrl = dto.AvatarUrl,
            IsVerified = dto.IsVerified
        };

        public static UserSummaryDto ToDto(this UserSummaryVM vm) =>
            new() {
                Id = vm.Id,
                DisplayedName = vm.DisplayedName,
                Username = vm.Username,
                AvatarUrl = vm.AvatarUrl,
                IsVerified = vm.IsVerified
            };
    }
}
