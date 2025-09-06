using Plenumio.Web.Models.Filter;

namespace Plenumio.Web.Models.Search {
    public record SearchVM {
        public UserFilterVM UserFilters { get; init; } = new();
        public TagFilterVM TagFilters { get; init; } = new();
        public PostFilterVM PostFilters { get; init; } = new();
    }
}
