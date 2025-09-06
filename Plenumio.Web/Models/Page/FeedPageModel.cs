using Plenumio.Web.Models.Filter;

namespace Plenumio.Web.Models.Page {
    public record FeedPageModel {
        public IEnumerable<PostFeedViewModel> Posts { get; init; } = [];
        public PostFilterVM Filters { get; init; } = new();

    }
}
