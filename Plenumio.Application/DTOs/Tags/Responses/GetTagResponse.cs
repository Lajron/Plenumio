using Plenumio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs.Tags.Responses {
    public record GetTagResponse {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string DisplayedName { get; init; } = string.Empty;
        public int PostsCount { get; init; }
        public int FollowersCount { get; init; }
        public bool IsFollowing { get; init; }
        public TagSummaryDto? Parent { get; init; }
        public IEnumerable<TagSummaryDto> Children { get; init; } = [];
    }
}
