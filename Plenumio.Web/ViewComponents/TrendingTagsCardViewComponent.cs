using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Plenumio.Application.DTOs;
using Plenumio.Application.DTOs.Tags;
using Plenumio.Application.Interfaces;
using Plenumio.Core.Entities;
using Plenumio.Core.Enums;
using Plenumio.Web.Mapping;
using Plenumio.Web.Models.Shared;
using Plenumio.Web.Models.Shared.ViewModels;

namespace Plenumio.Web.ViewComponents {
    public class TrendingTagsCardViewComponent(
            ITagService tagService
        ) : ViewComponent {
        public async Task<IViewComponentResult> InvokeAsync(Guid? currentUserId = null) {

            var tags = await tagService.GetAllTagsAsync(
                new TagFilterDto {
                    Sort = SortType.Trending,
                    PageSize = 5
                },
                currentUserId
            );

            var tagsVM = tags.Select(t => t.ToVM());

            return View(tagsVM);
        }
    }
}
