using Plenumio.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Core.Interfaces {
    public interface IUnitOfWork: IDisposable {
        ITagRepository Tags { get; }
        Task SaveChangesAsync();

    }
}
