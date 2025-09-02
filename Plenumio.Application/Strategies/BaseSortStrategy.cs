using Plenumio.Application.Interfaces;
using Plenumio.Core.Entities.Base;
using Plenumio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Strategies {
    public abstract class BaseSortStrategy<TEntity>
        : ISortStrategy<TEntity> where TEntity : class, IAuditableEntity {

        readonly Dictionary<SortType, Func<IQueryable<TEntity>, IQueryable<TEntity>>> _sortStrategies;

        protected BaseSortStrategy() {
            _sortStrategies = new() {
                [SortType.Newest] = ApplyNewestSort,
                [SortType.Oldest] = ApplyOldestSort,
                [SortType.Updated] = ApplyUpdatedSort,
                [SortType.Popular] = ApplyPopularSort,
                [SortType.Trending] = ApplyTrendingSort
            };
        }

        protected IQueryable<TEntity> ApplyNewestSort(IQueryable<TEntity> query) {
            return query.OrderByDescending(x => x.CreatedAt);
        }

        protected IQueryable<TEntity> ApplyOldestSort(IQueryable<TEntity> query) {
            return query.OrderBy(x => x.CreatedAt);
        }

        protected IQueryable<TEntity> ApplyUpdatedSort(IQueryable<TEntity> query) {
            return query.OrderByDescending(x => x.UpdatedAt);
        }

        protected abstract IQueryable<TEntity> ApplyPopularSort(IQueryable<TEntity> query);
        protected abstract IQueryable<TEntity> ApplyTrendingSort(IQueryable<TEntity> query);

        public IQueryable<TEntity> ApplySort(IQueryable<TEntity> query, SortType sort) {
            return _sortStrategies.TryGetValue(sort, out var strategy)
               ? strategy(query)
               : ApplyNewestSort(query);
        }
    }
}
