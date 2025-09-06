using Plenumio.Core.Enums;

namespace Plenumio.Web.Models.Filter {
    public record BaseFilterVM : PaginationVM {
        public SortType Sort { get; init; } = SortType.Newest;
        public DateTime? FromDate { get; init; }
        public DateTime? ToDate { get; init; }
    }
}
