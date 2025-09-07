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
            IUserService userService
        ) : ViewComponent {
        public async Task<IViewComponentResult> InvokeAsync(Guid? currentUserId = null) {
            
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
