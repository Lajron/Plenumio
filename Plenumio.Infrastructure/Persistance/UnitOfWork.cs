using Microsoft.EntityFrameworkCore;
using Plenumio.Core.Interfaces;
using Plenumio.Core.Interfaces.Repositories;
using Plenumio.Infrastructure.Data;
using Plenumio.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Infrastructure.Persistance {
    public class UnitOfWork(
            ApplicationDbContext db,
            ITagRepository tagRepository,
            IPostRepository postRepository,
            IUserRepository userRepository,
            ICommentRepository commentRepository
        ) : IUnitOfWork {

        private bool disposedValue;

        public ITagRepository Tags => tagRepository;
        public IPostRepository Posts => postRepository;
        public IUserRepository Users => userRepository;
        public ICommentRepository Comments => commentRepository;


        public async Task<int> CompleteAsync() {
            return await db.SaveChangesAsync();
        }

        public async Task ExecuteInTransactionAsync(Func<Task> trySection, Func<Exception, Task>? catchSection = null, Func<Task>? finallySection = null) {
            await using var transaction = await db.Database.BeginTransactionAsync();
            try {

                await trySection();
                await transaction.CommitAsync();

            } catch (Exception e) {

                await transaction.RollbackAsync();

                if (catchSection != null)
                    await catchSection(e);

            } finally {
                if (finallySection != null) await finallySection();
            }
        }

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    db.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose() {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

       
    }
}
