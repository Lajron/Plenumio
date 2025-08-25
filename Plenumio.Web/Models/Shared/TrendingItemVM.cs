namespace Plenumio.Web.Models.Shared {
    public class TrendingItemVM : BaseAspRoute {
        public required string DisplayText { get; set; }
        public string? ImageUrl { get; set; }
    }
}
