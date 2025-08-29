using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Queries.Feed {
    public record GetPostsForFeedQuery(int PageNumber, int PageSize);

}
