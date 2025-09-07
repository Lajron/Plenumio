using Plenumio.Application.DTOs.Common;

namespace Plenumio.Web.Models.Filter {
    public record TagFilterVM : BaseFilterVM {
        public string SearchTerm { get; init; } = string.Empty;

        public Guid? UserId { get; init; }

    }
}
