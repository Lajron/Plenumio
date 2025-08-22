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
    public class UnitOfWork(ApplicationDbContext db) : IUnitOfWork {
        private bool disposedValue;

        private readonly ITagRepository _tagRepository = new TagRepository(db);
        public ITagRepository Tags => _tagRepository;

        public async Task SaveChangesAsync() {
            await db.SaveChangesAsync();
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
