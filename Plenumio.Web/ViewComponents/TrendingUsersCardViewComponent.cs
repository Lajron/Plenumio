using Microsoft.AspNetCore.Mvc;
using Plenumio.Contracts.DTOs;

namespace Plenumio.Web.ViewComponents {
    public class TrendingUsersCardViewComponent : ViewComponent {
        public async Task<IViewComponentResult> InvokeAsync(int count = 5) {
            var mockUsers = new List<UserDto>
            {
                new UserDto(1, "milos", "https://picsum.photos/50"),
                new UserDto(2, "ana", "https://picsum.photos/51"),
                new UserDto(3, "marko", "https://picsum.photos/52"),
                new UserDto(4, "jovana", "https://picsum.photos/53"),
                new UserDto(5, "petar", "https://picsum.photos/54"),
                new UserDto(6, "sara", "https://picsum.photos/55")
            };

            var trendingUsers = mockUsers.Take(count);

            return View("TrendingUsersCard", trendingUsers);
        }
    }
}
