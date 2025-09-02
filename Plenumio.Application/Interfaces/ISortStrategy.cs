using Plenumio.Core.Entities;
using Plenumio.Core.Entities.Base;
using Plenumio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Interfaces {
    public interface ISortStrategy<TEntity> where TEntity : class, IAuditableEntity {
        IQueryable<TEntity> ApplySort(IQueryable<TEntity> query, SortType sort);

    }
}
