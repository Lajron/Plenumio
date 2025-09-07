namespace Plenumio.Web.Models.Profile {
    public record UserRelationshipVM {
        public Guid TargetUserId { get; init; }
        public FollowStatusOutgoingVM? Outgoing { get; init; }
        public FollowStatusIncomingVM? Incoming { get; init; }
    }
}
