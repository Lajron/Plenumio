using Plenumio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs.Reactions {
    public record ReactionSummaryDto {
        public ReactionType Type { get; init; }
        public int Count { get; init; }
        public bool IsCurrentUserReaction { get; init; }
    }
}
