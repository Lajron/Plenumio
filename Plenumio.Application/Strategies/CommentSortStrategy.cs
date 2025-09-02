using Plenumio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Strategies {
    public class CommentSortStrategy : BaseSortStrategy<Comment> {
        protected override IQueryable<Comment> ApplyPopularSort(IQueryable<Comment> query) {
            throw new NotImplementedException();
        }

        protected override IQueryable<Comment> ApplyTrendingSort(IQueryable<Comment> query) {
            throw new NotImplementedException();
        }
    }
}
