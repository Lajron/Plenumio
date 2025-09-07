using Plenumio.Core.Enums;

namespace Plenumio.Application.DTOs.Users.Responses {
    public record GetUserProfileResponse {
        public Guid Id { get; init; }
        public string DisplayedName { get; init; } = string.Empty;
        public string Username { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public string AvatarUrl { get; init; } = string.Empty;
        public string BackgroundUrl { get; init; } = string.Empty;
        public string Website { get; init; } = string.Empty;
        public bool IsVerified { get; init; }
        public int FollowersCount { get; init; }
        public int FollowingCount { get; init; }
        public int PostsCount { get; init; }
        public FollowStatus FollowStatusOutgoing { get; init; }
        public FollowStatus FollowStatusIncoming { get; init; }
    }
}
