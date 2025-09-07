using Plenumio.Application.DTOs.Users.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Interfaces {
    public interface IFollowService {
        Task<GetUserRelationshipResponse> RequestFollowAsync(Guid followerUserId, Guid followingUserId);
        Task<GetUserRelationshipResponse> AcceptFollowRequestAsync(Guid followerUserId, Guid followingUserId);
        Task<GetUserRelationshipResponse> DeclineFollowRequestAsync(Guid followerUserId, Guid followingUserId);
        Task<GetUserRelationshipResponse> UnfollowUserAsync(Guid followerUserId, Guid followingUserId);
        Task<GetUserRelationshipResponse> CancelFollowRequestAsync(Guid followerUserId, Guid followingUserId);
        Task<GetUserRelationshipResponse> BlockUserAsync(Guid blockingUserId, Guid blockedUserId);
    }
}
