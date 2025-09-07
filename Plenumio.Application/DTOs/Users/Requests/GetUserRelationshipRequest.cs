using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs.Users.Requests {
    public record GetUserRelationshipRequest {
        public Guid CurrentUserId { get; init; }
        public Guid TargetUserId { get; init; }

    }
}
