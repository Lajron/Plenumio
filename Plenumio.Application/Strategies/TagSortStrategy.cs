using Plenumio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Strategies {
    internal class TagSortStrategy : BaseSortStrategy<Tag> {
        protected override IQueryable<Tag> ApplyPopularSort(IQueryable<Tag> query) {
            return query.OrderByDescending(t => t.PostTag.Count + t.UserTags.Count * 2);
        }

        protected override IQueryable<Tag> ApplyTrendingSort(IQueryable<Tag> query) {
            var cutoff = DateTimeOffset.UtcNow.AddDays(-7);
            return query.OrderByDescending(t =>
                t.PostTag.Count(pt => pt.Post!.CreatedAt >= cutoff) +
                t.UserTags.Count(ut => ut.CreatedAt >= cutoff) * 2
            );
        }
    }
}
