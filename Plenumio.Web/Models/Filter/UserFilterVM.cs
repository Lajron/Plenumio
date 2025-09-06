using Plenumio.Application.DTOs.Common;

namespace Plenumio.Web.Models.Filter {
    public record UserFilterVM : BaseFilterVM {
        public string SearchTerm { get; init; } = string.Empty;
    }
}
