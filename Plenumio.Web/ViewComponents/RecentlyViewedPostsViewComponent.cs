using Microsoft.AspNetCore.Mvc;
using Plenumio.Application.DTOs;
using Plenumio.Web.Models.Shared;
using Plenumio.Web.Models.Shared.ViewModels;

namespace Plenumio.Web.ViewComponents {
    public class RecentlyViewedPostsViewComponent : ViewComponent {
        public async Task<IViewComponentResult> InvokeAsync(int count = 5) {
                    var mockPostItems = new List<TrendingItemVM>
        {
            new TrendingItemVM
            {
                DisplayText = "Prvi post o .NET razvoju 🚀",
                Controller = "Post",
                Action = "Index",
                RouteValues = new Dictionary<string, string> { { "slug", "prvi-post" } },
                ImageUrl = "https://picsum.photos/100/100"
            },
            new TrendingItemVM
            {
                DisplayText = "Fotografija sa letovanja 🌊",
                Controller = "Post",
                Action = "Index",
                RouteValues = new Dictionary<string, string> { { "slug", "fotografija-letovanje" } },
                ImageUrl = "https://picsum.photos/101/101"
            },
            new TrendingItemVM
            {
                DisplayText = "Novi projekat u toku ⚡",
                Controller = "Post",
                Action = "Index",
                RouteValues = new Dictionary<string, string> { { "slug", "novi-projekat" } },
                ImageUrl = "https://picsum.photos/100/100"
            },
            new TrendingItemVM
            {
                DisplayText = "Travel tips za leto 🏖️",
                Controller = "Post",
                Action = "Index",
                RouteValues = new Dictionary<string, string> { { "slug", "travel-tips" } },
                ImageUrl = "https://picsum.photos/102/102"
            },
            new TrendingItemVM
            {
                DisplayText = "Kuhinja kod kuće 🍳",
                Controller = "Post",
                Action = "Index",
                RouteValues = new Dictionary<string, string> { { "slug", "kuhinja-kod-kuce" } },
                ImageUrl = "https://picsum.photos/103/103"
            }
        };
                    var trendingPostsModel = new TrendingCardVM {
                        Title = "Trending Posts",
                        Items = mockPostItems,
                        Controller = "Post",
                        Action = "Index",
                        RouteValues = null,
                        ViewMoreText = "View all posts"
                    };

            return View(trendingPostsModel);
        }
    }
}
