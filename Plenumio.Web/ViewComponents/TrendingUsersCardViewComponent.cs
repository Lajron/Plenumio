using Microsoft.AspNetCore.Mvc;
using Plenumio.Application.DTOs;
using Plenumio.Web.Models.Shared;
using Plenumio.Web.Models.Shared.ViewModels;

namespace Plenumio.Web.ViewComponents {
    public class TrendingUsersCardViewComponent : ViewComponent {
        public async Task<IViewComponentResult> InvokeAsync(int count = 5) {
            var mockUsers = new List<TrendingItemVM>
{
    new TrendingItemVM
    {
        DisplayText = "milos",
        Controller = "Users",
        Action = "Profile",
        RouteValues = new Dictionary<string, string> { { "username", "milos" } },
        ImageUrl = "https://picsum.photos/50",
    },
    new TrendingItemVM
    {
        DisplayText = "ana",
        Controller = "Users",
        Action = "Profile",
        RouteValues = new Dictionary<string, string> { { "username", "ana" } },
        ImageUrl = "https://picsum.photos/51",
    },
    new TrendingItemVM
    {
        DisplayText = "marko",
        Controller = "Users",
        Action = "Profile",
        RouteValues = new Dictionary<string, string> { { "username", "marko" } },
        ImageUrl = "https://picsum.photos/52",
    },
    new TrendingItemVM
    {
        DisplayText = "jovana",
        Controller = "Users",
        Action = "Profile",
        RouteValues = new Dictionary<string, string> { { "username", "jovana" } },
        ImageUrl = "https://picsum.photos/53",
    },
    new TrendingItemVM
    {
        DisplayText = "petar",
        Controller = "Users",
        Action = "Profile",
        RouteValues = new Dictionary<string, string> { { "username", "petar" } },
        ImageUrl = "https://picsum.photos/54",
    },
    new TrendingItemVM
    {
        DisplayText = "sara",
        Controller = "Users",
        Action = "Profile",
        RouteValues = new Dictionary<string, string> { { "username", "sara" } },
        ImageUrl = "https://picsum.photos/55",
    }
};

            // Zatim kreiraš TrendingCardViewModel
            var trendingUsersModel = new TrendingCardVM {
                Title = "Trending Users",
                Items = mockUsers,
                Controller = "Users",
                Action = "Index",
                RouteValues = null,
                ViewMoreText = "View all users"
            };

            return View(trendingUsersModel);
        }
    }
}
