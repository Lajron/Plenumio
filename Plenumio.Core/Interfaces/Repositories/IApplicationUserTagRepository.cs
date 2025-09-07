using Plenumio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Core.Interfaces.Repositories {
    public interface IApplicationUserTagRepository : IRepository<ApplicationUserTag> {

        public Task<ApplicationUserTag?> FindByTagAndUserAsync(Guid tagId, Guid userId);
    }
}
