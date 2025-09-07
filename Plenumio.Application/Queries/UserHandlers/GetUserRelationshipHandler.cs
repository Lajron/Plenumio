using Microsoft.EntityFrameworkCore;
using Plenumio.Application.DTOs.Users.Requests;
using Plenumio.Application.DTOs.Users.Responses;
using Plenumio.Core.Enums;
using Plenumio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Queries.UserHandlers {
    public class GetUserRelationshipHandler(
        ApplicationDbContext db
        ) : IQueryHandler<GetUserRelationshipRequest, GetUserRelationshipResponse> {
        public async Task<GetUserRelationshipResponse> HandleAsync(GetUserRelationshipRequest query, CancellationToken cancellationToken = default) {
            var result = await db.Follows
                .Select(f => new GetUserRelationshipResponse {
                    CurrentUserStatus = f.FollowerId == query.CurrentUserId && f.FollowingId == query.TargetUserId ? f.Status : FollowStatus.None,
                    TargetUserStatus = f.FollowerId == query.TargetUserId && f.FollowingId == query.CurrentUserId ? f.Status : FollowStatus.None
                })
                .FirstOrDefaultAsync(cancellationToken);

            return result ?? new GetUserRelationshipResponse {
                CurrentUserStatus = FollowStatus.None,
                TargetUserStatus = FollowStatus.None
            };
        }
    }
}
