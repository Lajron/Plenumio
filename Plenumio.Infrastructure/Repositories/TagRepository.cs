using Plenumio.Core.Entities;
using Plenumio.Core.Interfaces.Repositories;
using Plenumio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Infrastructure.Repositories {
    public class TagRepository(PlenumioDbContext db) : Repository<Tag>(db), ITagRepository  {
    }
}
