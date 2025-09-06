using Plenumio.Application.DTOs.Common;
using Plenumio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs.Posts {
    public record PostFilterDto : BaseFilterDto {
        public FeedScope Scope { get; init; } = FeedScope.Personal;

        public Guid? TagId { get; init; }
        public Guid? UserId { get; init; }

        public string? Username { get; init; }
        public string? Search { get; init; }
        public string? Tag { get; init; }

        public PostType? PostType { get; init; }
        
    }
}
