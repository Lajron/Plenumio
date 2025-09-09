using Plenumio.Application.DTOs.Users.Requests;
using Plenumio.Application.DTOs.Users.Responses;
using Plenumio.Application.Interfaces;
using Plenumio.Application.Queries;
using Plenumio.Application.Validation;
using Plenumio.Core.Entities;
using Plenumio.Core.Enums;
using Plenumio.Core.Exceptions;
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
            followerUserId.IsNotEqualTo(followingUserId, nameof(followerUserId));

            var followTask = await uof.Follows.FindFollowingStatus(followerUserId, followingUserId);

            if (followTask is not null) {
                switch (followTask.Status) {
                    case FollowStatus.Pending:
                        throw new ConflictException("A follow request is already pending.");
                    case FollowStatus.Accepted:
                        throw new ConflictException("You are already following this user.");
                    case FollowStatus.Declined:
                    case FollowStatus.None:
                        followTask.Status = FollowStatus.Pending;
                        uof.Follows.Update(followTask);
                        break;
                }
            } else {
                var newFollow = new Follow {
                    FollowerId = followerUserId,
                    FollowingId = followingUserId,
                    Status = FollowStatus.Pending,
                };
                await uof.Follows.AddAsync(newFollow);
            }

            await uof.CompleteAsync();

            return await GetUserRelationship(followerUserId, followingUserId);
        }

        public async Task<GetUserRelationshipResponse> AcceptFollowRequestAsync(Guid followerUserId, Guid followingUserId) {
            followerUserId.IsNotEqualTo(followingUserId, nameof(followerUserId));

            var edge = await uof.Follows.FindFollowingStatus(followerUserId, followingUserId)
                ?? throw new NotFoundException("No follow request found to accept.", "Follow", new { followerUserId, followingUserId });

            if (edge.Status != FollowStatus.Pending)
                throw new ValidationException("Follow is not pending and cannot be accepted.");

            edge.Status = FollowStatus.Accepted;
            uof.Follows.Update(edge);
            await uof.CompleteAsync();

            // Perspective: acceptor (followingUserId) is current user
            return await GetUserRelationship(followingUserId, followerUserId);
        }

        public async Task<GetUserRelationshipResponse> DeclineFollowRequestAsync(Guid followerUserId, Guid followingUserId) {
            followerUserId.IsNotEqualTo(followingUserId, nameof(followerUserId));

            var followTask = await uof.Follows.FindFollowingStatus(followerUserId, followingUserId)
                ?? throw new NotFoundException("No follow request found to decline.", "Follow", new { followerUserId, followingUserId });

            if (followTask.Status != FollowStatus.Pending)
                throw new ValidationException("Follow is not pending and cannot be declined.");

            followTask.Status = FollowStatus.Declined;
            uof.Follows.Update(followTask);
            await uof.CompleteAsync();

            return await GetUserRelationship(followingUserId, followerUserId);
        }

        public async Task<GetUserRelationshipResponse> UnfollowUserAsync(Guid followerUserId, Guid followingUserId) {
            followerUserId.IsNotEqualTo(followingUserId, nameof(followerUserId));

            var followTask = await uof.Follows.FindFollowingStatus(followerUserId, followingUserId)
                ?? throw new NotFoundException("No active follow relationship found to unfollow.", "Follow", new { followerUserId, followingUserId });


            if (followTask.Status != FollowStatus.Accepted)
                throw new ValidationException("Only an accepted follow can be unfollowed.");

            uof.Follows.Remove(followTask);

            await uof.CompleteAsync();

            return await GetUserRelationship(followerUserId, followingUserId);
        }

        public async Task<GetUserRelationshipResponse> CancelFollowRequestAsync(Guid followerUserId, Guid followingUserId) {
            followerUserId.IsNotEqualTo(followingUserId, nameof(followerUserId));

            var followTask = await uof.Follows.FindFollowingStatus(followerUserId, followingUserId)
                ?? throw new NotFoundException("No follow request found to cancel.", "Follow", new { followerUserId, followingUserId });

            if (followTask.Status != FollowStatus.Pending)
                throw new ValidationException("Only a pending follow request can be cancelled.");

            uof.Follows.Remove(followTask);

            await uof.CompleteAsync();

            return await GetUserRelationship(followerUserId, followingUserId);
        }

        public Task<GetUserRelationshipResponse> BlockUserAsync(Guid blockingUserId, Guid blockedUserId) {
            // Blocking should probably be its own thing...
            throw new NotImplementedException();
        }

        private async Task<GetUserRelationshipResponse> GetUserRelationship(Guid currentUserId, Guid targetUserId) {
            return await queryDispatcher.SendAsync<GetUserRelationshipRequest, GetUserRelationshipResponse>(
                new GetUserRelationshipRequest {
                    CurrentUserId = currentUserId,
                    TargetUserId = targetUserId
                });
        }
    }
}
