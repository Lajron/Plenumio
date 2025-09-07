using Plenumio.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Core.Interfaces {
    public interface IUnitOfWork: IDisposable {
        ITagRepository Tags { get; }
        IPostRepository Posts { get; }
        IUserRepository Users { get; }
        ICommentRepository Comments { get; }
        IApplicationUserTagRepository ApplicationUserTags { get; }
        IFollowRepository Follows { get; }


        Task<int> CompleteAsync();
        Task ExecuteInTransactionAsync(Func<Task> trySection, Func<Exception, Task>? catchSection = null, Func<Task>? finallySection = null);


    }
}
