using Plenumio.Web.Models.Filter;
using Plenumio.Web.Models.Profile;

namespace Plenumio.Web.Models.Page {
    public record ProfilePageModel {
        public UserVM Profile { get; init; } = new();
        public PostFilterVM PostFilters { get; init; } = new();
    }
}
