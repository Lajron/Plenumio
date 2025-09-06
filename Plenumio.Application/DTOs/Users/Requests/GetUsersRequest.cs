using Plenumio.Application.DTOs.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs.Users.Requests {
    public record GetUsersRequest {
        public UserFilterDto Filters { get; init; } = new();
        public Guid? UserId { get; init; }
    }
}
