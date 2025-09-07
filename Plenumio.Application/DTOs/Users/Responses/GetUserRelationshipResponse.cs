using Plenumio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs.Users.Responses {
    public record GetUserRelationshipResponse {
        public FollowStatus CurrentUserStatus { get; init; }
        public FollowStatus TargetUserStatus { get; init; }
    }
}
