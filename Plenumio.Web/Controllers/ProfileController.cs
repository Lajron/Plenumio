using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Plenumio.Application.DTOs.Tags;
using Plenumio.Application.DTOs.Users;
using Plenumio.Application.Interfaces;
using Plenumio.Application.Services;
using Plenumio.Core.Entities;
using Plenumio.Core.Enums;
using Plenumio.Web.Mapping;
using Plenumio.Web.Models.Filter;
using Plenumio.Web.Models.Page;
using Plenumio.Web.Models.Profile;
using System.Threading.Tasks;

namespace Plenumio.Web.Controllers {
    public class ProfileController(
            IUserService userService,
            UserManager<ApplicationUser> userManager
        ) : Controller {

        [HttpGet("Profiles")]
        public async Task<IActionResult> All(UserFilterVM filters) {
            string? userId = userManager.GetUserId(User);
            Guid? currentUserId = string.IsNullOrEmpty(userId) ? null : Guid.Parse(userId);

            var filtersDto = new UserFilterDto {
                SearchTerm = filters.SearchTerm
            };

            var users = await userService.GetAllUsersAsync(filtersDto, currentUserId);

            var usersVM = users.Select(u => u.ToVM());

            var result = new PageVM<IEnumerable<UserSummaryVM>> {
                Content = usersVM,
                Title = "Profiles"
            };
            return View(result);
        }

        [HttpGet("Profile/{username}")]
        public async Task<IActionResult> Index(string username, PostFilterVM filtersVM) {
            string? userId = userManager.GetUserId(User);
            Guid? currentUserId = string.IsNullOrEmpty(userId) ? null : Guid.Parse(userId);

            var user = await userService.GetUserProfile(username, currentUserId);

            if (user is null) return NotFound();

            filtersVM = filtersVM with {
                Scope = FeedScope.Global,
                Username = username
            };

            var userVM = user.ToVM();

            var result = new PageVM<ProfilePageModel> {
                Content = new ProfilePageModel {
                    Profile = userVM,
                    PostFilters = filtersVM
                },
                Title = userVM.DisplayedName,
                CurrentUserId = currentUserId
            };

            return View(result);
        }

        
    }
}
