using Plenumio.Core.Entities;
using Plenumio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Strategies {
    public class PostSortStrategy : BaseSortStrategy<Post> {
        protected override IQueryable<Post> ApplyPopularSort(IQueryable<Post> query) {
            return query.OrderByDescending(p => p.Reactions.Count + p.Comments.Count);
        }

        protected override IQueryable<Post> ApplyTrendingSort(IQueryable<Post> query) {
            return query.OrderByDescending(p => p.CreatedAt)
                        .ThenByDescending(p => p.Comments.Count + p.Reactions.Count);
        }

    }
}
