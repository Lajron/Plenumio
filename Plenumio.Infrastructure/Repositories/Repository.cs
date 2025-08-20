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
    public class Repository<T>(PlenumioDbContext db) : IRepository<T> where T : class {
        protected DbSet<T> dbSet = db.Set<T>();
        public async Task AddAsync(T entity) {
            await dbSet.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> predicate) {
            IQueryable<T> query = dbSet;
            query = query.Where(predicate);
            return await query.ToListAsync();
        }

        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate) {
            IQueryable<T> query = dbSet;
            query = query.Where(predicate);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<T?> GetByIdAsync(int id) {
            return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync() {
            return await dbSet.ToListAsync();
        }

        public Task Update(T entity) {
            dbSet.Update(entity);
            return Task.CompletedTask;
        }

        public Task Patch(T entity) {
            throw new NotImplementedException();
        }

        public Task Remove(T entity) {
            dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task RemoveById(int id) {
            T? entity = await dbSet.FindAsync(id);
            if (entity is not null) {
                dbSet.Remove(entity);
            }
        }

        public Task RemoveRange(IEnumerable<T> entities) {
            dbSet.RemoveRange(entities);
            return Task.CompletedTask;
        }

        
    }
}
