using Microsoft.EntityFrameworkCore;
using Plenumio.Application.DTOs.Users.Requests;
using Plenumio.Application.DTOs.Users.Responses;
using Plenumio.Application.Interfaces;
using Plenumio.Core.Enums;
using Plenumio.Infrastructure.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Plenumio.Infrastructure.Queries.UserHandlers {
    public class GetUserRelationshipHandler(
        ApplicationDbContext db
    ) : IQueryHandler<GetUserRelationshipRequest, GetUserRelationshipResponse> {

        public async Task<GetUserRelationshipResponse> HandleAsync(GetUserRelationshipRequest query, CancellationToken cancellationToken = default) {

            var edges = await db.Follows
                .Where(f =>
                       f.FollowerId == query.CurrentUserId && f.FollowingId == query.TargetUserId ||
                       f.FollowerId == query.TargetUserId && f.FollowingId == query.CurrentUserId)
                .Select(f => new { f.FollowerId, f.FollowingId, f.Status })
                .ToListAsync(cancellationToken);

            var outgoing = edges
                .FirstOrDefault(e => e.FollowerId == query.CurrentUserId && e.FollowingId == query.TargetUserId)?.Status
                ?? FollowStatus.None;

            var incoming = edges
                .FirstOrDefault(e => e.FollowerId == query.TargetUserId && e.FollowingId == query.CurrentUserId)?.Status
                ?? FollowStatus.None;

            return new GetUserRelationshipResponse {
                CurrentUserStatus = outgoing,
                TargetUserStatus = incoming
            };
        }
    }
}
