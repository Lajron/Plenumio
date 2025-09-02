using Plenumio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Strategies {
    public class UserSortStrategy : BaseSortStrategy<ApplicationUser> {
        protected override IQueryable<ApplicationUser> ApplyPopularSort(IQueryable<ApplicationUser> query) {
            return query.OrderByDescending(u => u.Followers);
        }

        protected override IQueryable<ApplicationUser> ApplyTrendingSort(IQueryable<ApplicationUser> query) {
            return query.OrderByDescending(u => u.Posts.Count);

        }
    }
}
