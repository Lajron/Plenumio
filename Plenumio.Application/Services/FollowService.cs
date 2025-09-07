using Plenumio.Application.DTOs.Users.Requests;
using Plenumio.Application.DTOs.Users.Responses;
using Plenumio.Application.Interfaces;
using Plenumio.Application.Queries;
using Plenumio.Core.Entities;
using Plenumio.Core.Enums;
using Plenumio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Services {
    public class FollowService(
            IUnitOfWork uof,
            IQueryDispatcher queryDispatcher
    ) : IFollowService {
        public async Task<GetUserRelationshipResponse> RequestFollowAsync(Guid followerUserId, Guid followingUserId) {
            if (followerUserId == followingUserId)
                throw new ArgumentException("A user cannot follow themselves.");

            var followTask = await uof.Follows.FindFollowingStatus(followerUserId, followingUserId);

            if (followTask is not null) {
                if (followTask.Status == FollowStatus.Pending)
                    throw new InvalidOperationException("A follow request is already pending.");
                if (followTask.Status == FollowStatus.Accepted)
                    throw new InvalidOperationException("You are already following this user.");
            }

            var newFollow = new Follow {
                FollowerId = followerUserId,
                FollowingId = followingUserId,
                Status = FollowStatus.Pending,
            };

            await uof.Follows.AddAsync(newFollow);

            await uof.CompleteAsync();

            return await queryDispatcher.SendAsync<GetUserRelationshipRequest, GetUserRelationshipResponse>(new GetUserRelationshipRequest {
                CurrentUserId = followerUserId,
                TargetUserId = followingUserId
            });
        }

        public async Task<GetUserRelationshipResponse> AcceptFollowRequestAsync(Guid followerUserId, Guid followingUserId) {
            var followTask = await uof.Follows.FindFollowingStatus(followerUserId, followingUserId);

            if (followTask is null)
                throw new InvalidOperationException("No follow request found to accept.");

            if (followTask.Status != FollowStatus.Pending)
                throw new InvalidOperationException("Follow request is not in a pending state.");

            followTask.Status = FollowStatus.Accepted;

            uof.Follows.Update(followTask);

            await uof.CompleteAsync();

            return await queryDispatcher.SendAsync<GetUserRelationshipRequest, GetUserRelationshipResponse>(new GetUserRelationshipRequest {
                CurrentUserId = followerUserId,
                TargetUserId = followingUserId
            });
        }

        public async Task<GetUserRelationshipResponse> DeclineFollowRequestAsync(Guid followerUserId, Guid followingUserId) {
            var followTask = await uof.Follows.FindFollowingStatus(followerUserId, followingUserId);

            if (followTask is null)
                throw new InvalidOperationException("No follow request found to decline.");

            if (followTask.Status != FollowStatus.Pending)
                throw new InvalidOperationException("Follow request is not in a pending state.");

            followTask.Status = FollowStatus.Declined;

            uof.Follows.Update(followTask);

            await uof.CompleteAsync();

            return await queryDispatcher.SendAsync<GetUserRelationshipRequest, GetUserRelationshipResponse>(new GetUserRelationshipRequest {
                CurrentUserId = followerUserId,
                TargetUserId = followingUserId
            });
        }

        public async Task<GetUserRelationshipResponse> UnfollowUserAsync(Guid followerUserId, Guid followingUserId) {
            var followTask = await uof.Follows.FindFollowingStatus(followerUserId, followingUserId);

            if (followTask is null || followTask.Status != FollowStatus.Accepted)
                throw new InvalidOperationException("No active follow relationship found to unfollow.");

            uof.Follows.Update(followTask);

            await uof.CompleteAsync();

            return await queryDispatcher.SendAsync<GetUserRelationshipRequest, GetUserRelationshipResponse>(new GetUserRelationshipRequest {
                CurrentUserId = followerUserId,
                TargetUserId = followingUserId
            });
        }

        public async Task<GetUserRelationshipResponse> CancelFollowRequestAsync(Guid followerUserId, Guid followingUserId) {
            var followTask = await uof.Follows.FindFollowingStatus(followerUserId, followingUserId);

            if (followTask is null)
                throw new InvalidOperationException("No follow request found to cancel.");

            if (followTask.Status != FollowStatus.Pending)
                throw new InvalidOperationException("Follow request is not in a pending state.");

            uof.Follows.Remove(followTask);

            await uof.CompleteAsync();

            return await queryDispatcher.SendAsync<GetUserRelationshipRequest, GetUserRelationshipResponse>(new GetUserRelationshipRequest {
                CurrentUserId = followerUserId,
                TargetUserId = followingUserId
            });
        }

        public Task<GetUserRelationshipResponse> BlockUserAsync(Guid blockingUserId, Guid blockedUserId) {
            throw new NotImplementedException();
        }
    }
}
