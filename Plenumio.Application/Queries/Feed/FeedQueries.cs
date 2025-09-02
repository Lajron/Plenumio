using Plenumio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Queries.Feed {
    public record GetPostsForFeedQuery(
        int PageNumber, 
        int PageSize
    );

    public record FeedFilterQuery {
        public FeedScope Scope { get; init; } = FeedScope.Personal;
        public SortType Sort { get; init; } = SortType.Newest;
        public int Page { get; init; } = 1;
        public int PageSize { get; init; } = 20;
        public string? Search { get; init; }
        public string? Tag { get; init; }
        public PostType? PostType { get; init; }
        public DateTime? FromDate { get; init; }
        public DateTime? ToDate { get; init; }
    }




}
