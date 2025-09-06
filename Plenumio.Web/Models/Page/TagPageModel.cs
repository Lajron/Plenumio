using Plenumio.Web.Models.Filter;
using Plenumio.Web.Models.Profile;
using Plenumio.Web.Models.Tag;

namespace Plenumio.Web.Models.Page {
    public record TagPageModel {
        public TagVM Tag { get; init; } = new();
        public PostFilterVM PostFilters { get; init; } = new();
    }
}
