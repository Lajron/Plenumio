using Plenumio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Core.Interfaces.Repositories {
    public interface IPostRepository : IRepository<Post> {
        Task<string?> GetSlugById(Guid id);
    }
}
