using Plenumio.Application.DTOs.Posts;
using Plenumio.Application.DTOs.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public bool IsFollowing { get; init; }
    }
}
