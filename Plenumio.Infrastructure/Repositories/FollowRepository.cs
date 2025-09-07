using Microsoft.EntityFrameworkCore;
using Plenumio.Core.Entities;
using Plenumio.Core.Interfaces.Repositories;
using Plenumio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Infrastructure.Repositories {
    public class FollowRepository(ApplicationDbContext db)
        : BaseRepository<Follow>(db), IFollowRepository {
        public async Task<Follow?> FindFollowingStatus(Guid followerId, Guid followingId) {
            return await _dbSet
                .Where(f => f.FollowerId == followerId && f.FollowingId == followingId)
                .FirstOrDefaultAsync();
        }
    }
}
