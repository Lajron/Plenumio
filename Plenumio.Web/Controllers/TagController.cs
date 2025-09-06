using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Plenumio.Application.DTOs;
using Plenumio.Application.DTOs.Tags;
using Plenumio.Application.Interfaces;
using Plenumio.Application.Services;
using Plenumio.Core.Entities;
using Plenumio.Core.Enums;
using Plenumio.Web.Mapping;
using Plenumio.Web.Models;
using Plenumio.Web.Models.Filter;
using Plenumio.Web.Models.Page;
using Plenumio.Web.Models.Profile;
using Plenumio.Web.Models.Tag;

namespace Plenumio.Web.Controllers {
    public class TagController(
            ITagService tagService,
            UserManager<ApplicationUser> userManager
        ) : Controller {

        [HttpGet("Tags")]
        public async Task<IActionResult> Index(TagFilterVM filters) {
            string? userId = userManager.GetUserId(User);
            Guid? currentUserId = string.IsNullOrEmpty(userId) ? null : Guid.Parse(userId);

            var filtersDto = new TagFilterDto {
                SearchTerm = filters.SearchTerm
            };

            var tags = await tagService.GetTagsAsync(filtersDto, currentUserId);

            var tagsVM = tags.Select(t => t.ToVM());

            var result = new PageVM<IEnumerable<TagVM>> {
                Content = tagsVM,
                Title = "Tags"
            };
            return View(result);
        }

        [HttpGet("Tag/Details/{tagName}")]
        public async Task<IActionResult> Details(string tagName, PostFilterVM filtersVM) {
            string? userId = userManager.GetUserId(User);
            Guid? currentUserId = string.IsNullOrEmpty(userId) ? null : Guid.Parse(userId);

            var tag = await tagService.GetTagAsync(tagName, currentUserId);

            if (tag is null) return NotFound();

            filtersVM = filtersVM with { 
                Scope = FeedScope.Global,
                Tag = tagName
            };

            var tagVM = tag.ToVM();

            var result = new PageVM<TagPageModel> {
                Content = new TagPageModel {
                    Tag = tagVM,
                    PostFilters = filtersVM
                },
                Title = tagVM.DisplayedName,
                CurrentUserId = currentUserId
            };

            return View(result);
        }
    }
}
