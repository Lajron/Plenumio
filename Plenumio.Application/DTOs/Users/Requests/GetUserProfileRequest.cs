using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs.Users.Requests {
    public record GetUserProfileRequest {
        public string Username { get; init; } = string.Empty;
        public Guid? CurrentUserId { get; init; }
    }
}
