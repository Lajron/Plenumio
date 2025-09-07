using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Plenumio.Application.DTOs.Tags;
using Plenumio.Application.Interfaces;
using Plenumio.Core.Entities;
using Plenumio.Core.Enums;
using Plenumio.Web.Mapping;

namespace Plenumio.Web.ViewComponents {
    public class PersonalTags(
        ITagService tagService
    ) : ViewComponent {
        public async Task<IViewComponentResult> InvokeAsync(Guid? currentUserId) {
            var tags = await tagService.GetAllTagsAsync(
                new TagFilterDto {
                    Sort = SortType.Newest,
                    UserId = currentUserId,
                    PageSize = 100
                },
                currentUserId
            );

            var tagsVM = tags.Select(t => t.ToVM());

            return View(tagsVM);
        }
    }
}
