using Microsoft.EntityFrameworkCore;
using Plenumio.Core.Interfaces.Repositories;
using Plenumio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Infrastructure.Repositories {
    public class BaseRepository<TEntity>(ApplicationDbContext db) : IRepository<TEntity> where TEntity : class {
        protected readonly DbSet<TEntity> _dbSet = db.Set<TEntity>();

        public async Task<TEntity?> FindByIdAsync(Guid id) {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync() {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(TEntity entity) {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities) {
            await _dbSet.AddRangeAsync(entities);
        }

        public void Update(TEntity entity) {
            _dbSet.Update(entity);
        }

        public void Remove(TEntity entity) {
            _dbSet.Remove(entity);
        }

        public async Task RemoveByIdAsync(Guid id) {
            TEntity? entity = await _dbSet.FindAsync(id);
            if (entity != null)
                _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities) {
            _dbSet.RemoveRange(entities);
        }

        
    }
}
