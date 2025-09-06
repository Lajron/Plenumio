namespace Plenumio.Web.Models.Filter {
    public record PaginationVM {

        public int Page { get; init; } = 1;
        public int PageSize { get; init; } = 20;

        //public int TotalCount { get; init; }
    }
}
