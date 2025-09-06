using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs.Users.Responses {
    public record LoginUserResponse {
        public Guid UserId { get; init; }
        public string Username { get; init; } = string.Empty;
    }
}
