using Microsoft.AspNetCore.Mvc;
using Plenumio.Application.DTOs;
using Plenumio.Web.Models.Shared;
using Plenumio.Web.Models.Shared.ViewModels;

namespace Plenumio.Web.ViewComponents {
    public class TrendingTagsCardViewComponent : ViewComponent {
        public async Task<IViewComponentResult> InvokeAsync() {
            var tags = new List<TrendingItemVM> { 
            new TrendingItemVM
            {
                DisplayText = "#C#",
                Controller = "Tags",
                Action = "Details",
                RouteValues = new Dictionary<string, string> { { "tagName", "csharp" } },
                ImageUrl = null // tags nemaju avatare
            },
            new TrendingItemVM
            {
                DisplayText = "#.NET",
                Controller = "Tags",
                Action = "Details",
                RouteValues = new Dictionary<string, string> { { "tagName", "csharp" } },
                ImageUrl = null
            },
            new TrendingItemVM
            {
                DisplayText = "#Blazor",
                Controller = "Tags",
                Action = "Details",
                RouteValues = new Dictionary<string, string> { { "tagName", "csharp" } },
                ImageUrl = null
            },
            new TrendingItemVM
            {
                DisplayText = "#SQL",
                Controller = "Tags",
                Action = "Details",
                RouteValues = new Dictionary < string, string > { { "tagName", "csharp" } },
                ImageUrl = null
            },
            new TrendingItemVM
            {
                DisplayText = "#Azure",
                Controller = "Tags",
                Action = "Details",
                RouteValues = new Dictionary < string, string > { { "tagName", "csharp" } },
                ImageUrl = null
            }
            };

            // Zatim kreirati TrendingCardViewModel
            var trendingCardModel = new TrendingCardVM {
                Title = "Trending Tags",
                Items = tags,
                Controller = "Tag",
                Action = "Index",
                RouteValues = null,
                ViewMoreText = "View all tags"
            };


            return View(trendingCardModel);
        }
    }
}
