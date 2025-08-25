namespace Plenumio.Web.Models.Shared.ViewModels {
    public class TrendingCardVM : BaseAspRoute {
        public required string Title { get; set; } 
        public List<TrendingItemVM> Items { get; set; } = [];
        public string? ViewMoreText { get; set; } 
    }
}
