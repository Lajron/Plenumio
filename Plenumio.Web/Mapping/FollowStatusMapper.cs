using Plenumio.Application.DTOs.Users.Responses;
using Plenumio.Core.Enums;
using Plenumio.Web.Models.Profile;

namespace Plenumio.Web.Mapping {
    public static class FollowStatusMapper {
        public static FollowStatusOutgoingVM? ToOutgoingVM(this FollowStatus status) {
            return status switch {
                FollowStatus.None => FollowStatusOutgoingVM.Follow,
                FollowStatus.Pending => FollowStatusOutgoingVM.Pending,
                FollowStatus.Accepted => FollowStatusOutgoingVM.Unfollow,
                FollowStatus.Declined => null,
                _ => FollowStatusOutgoingVM.Follow
            };
        }

        public static FollowStatusIncomingVM? ToIncomingVM(this FollowStatus status) {
            return status switch {
                FollowStatus.Pending => FollowStatusIncomingVM.Accept,
                FollowStatus.Accepted => FollowStatusIncomingVM.Following,
                FollowStatus.Declined => FollowStatusIncomingVM.Declined,
                _ => null
            };
        }

        public static UserRelationshipVM ToVM(this GetUserRelationshipResponse response, Guid targetUserId) {
            return new UserRelationshipVM {
                TargetUserId = targetUserId,
                Outgoing = response.CurrentUserStatus.ToOutgoingVM(),
                Incoming = response.TargetUserStatus.ToIncomingVM()
            };
        }
    }
}
