using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Plenumio.Application.DTOs;
using Plenumio.Application.DTOs.Tags;
using Plenumio.Application.Interfaces;
using Plenumio.Core.Entities;
using Plenumio.Core.Enums;
using Plenumio.Web.Models.Shared;
using Plenumio.Web.Models.Shared.ViewModels;

namespace Plenumio.Web.ViewComponents {
    public class TrendingTagsCardViewComponent(
            ITagService tagService,
            UserManager<ApplicationUser> userManager
        ) : ViewComponent {
        public async Task<IViewComponentResult> InvokeAsync() {
            string? userId = userManager.GetUserId(HttpContext.User);
            Guid? currentUserId = string.IsNullOrEmpty(userId) ? null : Guid.Parse(userId);

            var tags = await tagService.GetAllTagsAsync(
                new TagFilterDto {
                    Sort = SortType.Trending,
                    PageSize = 5
                },
                currentUserId
            );

            return View(tags);
        }
    }
}
