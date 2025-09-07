using LinqKit;
using Microsoft.EntityFrameworkCore;
using Plenumio.Application.DTOs.Users.Requests;
using Plenumio.Application.DTOs.Users.Responses;
using Plenumio.Application.Mapping;
using Plenumio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Queries.UserHandlers {
    public class GetUserProfileHandler(
        ApplicationDbContext db
        ) : IQueryHandler<GetUserProfileRequest, GetUserProfileResponse?> {
        public async Task<GetUserProfileResponse?> HandleAsync(GetUserProfileRequest query, CancellationToken cancellationToken = default) {
            return await db.ApplicationUser
                .AsExpandable()
                .Where(u => u.UserName == query.Username.ToUpper())
                .Select(u => UserMapper.ToProfileDto().Invoke(u, query.CurrentUserId))
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
