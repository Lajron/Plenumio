using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Plenumio.Application.DTOs;
using Plenumio.Application.DTOs.Tags;
using Plenumio.Application.DTOs.Users;
using Plenumio.Application.Interfaces;
using Plenumio.Application.Services;
using Plenumio.Core.Entities;
using Plenumio.Core.Enums;
using Plenumio.Web.Models.Shared;
using Plenumio.Web.Models.Shared.ViewModels;

namespace Plenumio.Web.ViewComponents {
    public class TrendingUsersCardViewComponent(
            IUserService userService,
            UserManager<ApplicationUser> userManager
        ) : ViewComponent {
        public async Task<IViewComponentResult> InvokeAsync(int count = 5) {
            string? userId = userManager.GetUserId(HttpContext.User);
            Guid? currentUserId = string.IsNullOrEmpty(userId) ? null : Guid.Parse(userId);

            var tags = await userService.GetAllUsersAsync(
                new UserFilterDto {
                    Sort = SortType.Trending,
                    PageSize = 5
                },
                currentUserId
            );

            return View(tags);
        }
    }
}
