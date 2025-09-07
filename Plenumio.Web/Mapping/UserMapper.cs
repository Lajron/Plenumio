using Plenumio.Application.DTOs.Users;
using Plenumio.Application.DTOs.Users.Responses;
using Plenumio.Core.Enums;
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
                UserRelationshipVM = new UserRelationshipVM {
                    TargetUserId = dto.Id,
                    Outgoing = dto.FollowStatusOutgoing.ToOutgoingVM(),
                    Incoming = dto.FollowStatusIncoming.ToIncomingVM()
                }
            };
        }

        public static UserSummaryVM ToVM(this UserSummaryDto dto) {
            return new UserSummaryVM {
                Id = dto.Id,
                DisplayedName = dto.DisplayedName,
                Username = dto.Username,
                AvatarUrl = dto.AvatarUrl,
                IsVerified = dto.IsVerified
            };
        }


        public static UserSummaryDto ToDto(this UserSummaryVM vm) {
            return new UserSummaryDto {
                Id = vm.Id,
                DisplayedName = vm.DisplayedName,
                Username = vm.Username,
                AvatarUrl = vm.AvatarUrl,
                IsVerified = vm.IsVerified
            };
        }
    }
}
