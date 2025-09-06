using Plenumio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs.Tags {
    public record TagDetailsDto {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string DisplayedName { get; init; } = string.Empty;
        public TagType Type { get; init; }
        public DateTimeOffset CreatedAt { get; init; }
        public int PostsCount { get; init; }
        public int FollowersCount { get; init; }
        public bool IsFollowing { get; init; }
        public TagSummaryDto? Parent { get; init; }
        public List<TagSummaryDto> Children { get; init; } = [];
    }
}
