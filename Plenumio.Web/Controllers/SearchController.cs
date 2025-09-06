using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Plenumio.Core.Entities;
using Plenumio.Core.Enums;
using Plenumio.Web.Models.Filter;
using Plenumio.Web.Models.Page;
using Plenumio.Web.Models.Search;
using static NuGet.Packaging.PackagingConstants;

namespace Plenumio.Web.Controllers {
    public class SearchController(
            UserManager<ApplicationUser> userManager
        ): Controller {
        [HttpGet("Search/{search}")]
        public IActionResult Index(string search, PostFilterVM postFilters) {
            Guid? currentUserId = null;
            var userId = userManager.GetUserId(User);

            if (Guid.TryParse(userId, out var userIdGuid)) {
                currentUserId = userIdGuid;
            }

            var searchVM = new SearchVM {
                UserFilters = new UserFilterVM {
                    SearchTerm = search,
                    PageSize = 5
                },
                TagFilters = new TagFilterVM {
                    SearchTerm = search,
                    PageSize = 5
                },
                PostFilters = postFilters with {
                    SearchTerm = search,
                    Scope = FeedScope.Global,
                }
            };

            var result = new PageVM<SearchVM> {
                Content = searchVM,
                Title = $"Search {search}",
                CurrentUserId = currentUserId
            };

            return View(result);
        }
    }
}
