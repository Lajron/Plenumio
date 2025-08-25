using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Core.Interfaces.Repositories {
    public interface IRepository<TEntity> where TEntity: class {
        Task<TEntity?> GetAsync(
            Expression<Func<TEntity, bool>> filter,
            params Expression<Func<TEntity, object>>[] includes
        );

        Task<TResult?> GetAsync<TResult>(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, TResult>> selector,
            params Expression<Func<TEntity, object>>[] includes
        );

        Task<IEnumerable<TEntity>> FilterAsync(
            Expression<Func<TEntity, bool>> filter,
            params Expression<Func<TEntity, object>>[] includes
        );

        Task<IEnumerable<TResult>> FilterAsync<TResult>(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, TResult>> selector,
            params Expression<Func<TEntity, object>>[] includes
        );

        Task<IEnumerable<TResult>> FilterPagedAsync<TResult>(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, TResult>> selector,
            int skip,
            int take,
            params Expression<Func<TEntity, object>>[] includes
        );

        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        void Update(TEntity entity); 

        void Remove(TEntity entity);
        Task RemoveByIdAsync(int id);
        void RemoveRange(IEnumerable<TEntity> entities);


    }
}
