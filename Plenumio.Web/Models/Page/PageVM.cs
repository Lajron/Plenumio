using Plenumio.Web.Models.Filter;

namespace Plenumio.Web.Models.Page {
    public record PageVM<TContent> {
        public TContent Content { get; init; } = default!;
        public string Title { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public Guid? CurrentUserId { get; init; }
    }
}
