using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs.Users {
    public record UserSummaryDto {
        public Guid Id { get; init; }
        public string DisplayedName { get; init; } = string.Empty;
        public string Username { get; init; } = string.Empty;
        public string AvatarUrl { get; init; } = string.Empty;
        public bool IsVerified { get; init; }
    }

}
