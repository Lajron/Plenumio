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

        public async Task<TEntity?> GetAsync(
            Expression<Func<TEntity, bool>> filter,
            params Expression<Func<TEntity, object>>[] includes
        ) {
            IQueryable<TEntity> query = _dbSet;
            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            return await query.SingleOrDefaultAsync(filter);
        }

        public async Task<TResult?> GetAsync<TResult>(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, TResult>> selector,
            params Expression<Func<TEntity, object>>[] includes
        ) {
            IQueryable<TEntity> query = _dbSet;
            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            return await query.Where(filter).Select(selector).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> FilterAsync(
            Expression<Func<TEntity, bool>> filter,
            params Expression<Func<TEntity, object>>[] includes
        ) {
            IQueryable<TEntity> query = _dbSet;
            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            return await query.Where(filter).ToListAsync();
        }

        public async Task<IEnumerable<TResult>> FilterAsync<TResult>(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, TResult>> selector,
            params Expression<Func<TEntity, object>>[] includes
        ) {
            IQueryable<TEntity> query = _dbSet;
            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            return await query.Where(filter).Select(selector).ToListAsync();
        }

        public async Task<IEnumerable<TResult>> FilterPagedAsync<TResult>(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, TResult>> selector,
            int skip,
            int take,
            params Expression<Func<TEntity, object>>[] includes
        ) {
            IQueryable<TEntity> query = _dbSet;
            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            return await query.Where(filter).Skip(skip).Take(take).Select(selector).ToListAsync();
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

        public async Task RemoveByIdAsync(int id) {
            TEntity? entity = await _dbSet.FindAsync(id);
            if (entity != null)
                _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities) {
            _dbSet.RemoveRange(entities);
        }
    }
}
