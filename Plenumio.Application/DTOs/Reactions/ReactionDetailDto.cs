using Plenumio.Application.DTOs.Users;
using Plenumio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs.Reactions {
    public record ReactionDetailDto {
        public Guid Id { get; init; }
        public ReactionType Type { get; init; }
        public UserSummaryDto User { get; init; } = new();
    }
}
