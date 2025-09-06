using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Plenumio.Application.DTOs.Tags;
using Plenumio.Application.Interfaces;
using Plenumio.Core.Entities;
using Plenumio.Web.Mapping;
using Plenumio.Web.Models.Filter;
using Plenumio.Web.Models.Page;
using Plenumio.Web.Models.Tag;

namespace Plenumio.Web.ViewComponents {
    public class TagsViewComponent(
        ITagService tagService
    ) : ViewComponent {
        public async Task<IViewComponentResult> InvokeAsync(TagFilterVM filters, Guid? currentUserId) {
            var tagFilters = new TagFilterDto {
                SearchTerm = filters.SearchTerm,
                PageSize = filters.PageSize
            };
            var tags = await tagService.GetTagsAsync(tagFilters, currentUserId);

            var tagsVM = tags.Select(t => t.ToVM());

            var result = new PageVM<IEnumerable<TagVM>> {
                Content = tagsVM,
                Title = filters.SearchTerm
            };

            return View(result);
        }
    }
}
