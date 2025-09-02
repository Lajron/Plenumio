using Plenumio.Application.Queries.Feed;

namespace Plenumio.Web.Models {

    public record PageViewModel<TContent> {
        public TContent Content { get; init; } = default!;
        public string Title { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public PaginationViewModel? Pagination { get; init; }
    }
    public record PaginationViewModel {
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
        public int TotalCount { get; init; }
    }

    public record PostFeedPageModel {
        public IEnumerable<PostFeedViewModel> Posts { get; init; } = [];
        public FeedFilterQuery Filters { get; init; } = new();

    }


}
