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
    public class PostRepository(ApplicationDbContext db) 
        : BaseRepository<Post>(db), IPostRepository {

        public async Task<string?> GetSlugById(Guid id) {
            return await _dbSet.Where(p => p.Id == id).Select(p => p.Slug).SingleOrDefaultAsync();
        }
    }
}
