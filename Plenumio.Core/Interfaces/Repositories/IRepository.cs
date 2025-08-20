using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Core.Interfaces.Repositories {
    public interface IRepository<T> where T: class {
        Task AddAsync(T entity);

        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> predicate);
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task Update(T entity);
        Task Patch(T entity);
        Task Remove(T entity);
        Task RemoveById(int id);
        Task RemoveRange(IEnumerable<T> entities);


    }
}
