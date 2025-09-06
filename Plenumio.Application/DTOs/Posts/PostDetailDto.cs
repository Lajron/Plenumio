using Plenumio.Application.DTOs.Comments;
using Plenumio.Application.DTOs.Image;
using Plenumio.Application.DTOs.Reactions;
using Plenumio.Application.DTOs.Tags;
using Plenumio.Application.DTOs.Users;
using Plenumio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs.Posts {
    public record PostDetailsDto {
        public Guid Id { get; init; }
        public string Title { get; init; } = string.Empty;
        public string Content { get; init; } = string.Empty;
        public string Slug { get; init; } = string.Empty;
        public PostType Type { get; init; }
        public PrivacyType Privacy { get; init; }
        public UserSummaryDto Author { get; init; } = new();
        public DateTimeOffset CreatedAt { get; init; }
        public DateTimeOffset UpdatedAt { get; init; }
        public int CommentsCount { get; init; }
        public IEnumerable<Tags.TagSummaryDto> Tags { get; init; } = [];
        public IEnumerable<ReactionSummaryDto> Reactions { get; init; } = [];
        public IEnumerable<PostImageDto> Images { get; init; } = [];
    }
}
