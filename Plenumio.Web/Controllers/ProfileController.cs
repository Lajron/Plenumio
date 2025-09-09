using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
            IFollowService followService,
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

        

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RequestFollow(Guid userId) {
            var currentId = userManager.GetUserId(User);
            if (string.IsNullOrEmpty(currentId)) return Unauthorized();
            var currentUserId = Guid.Parse(currentId);

            var result = await followService.RequestFollowAsync(currentUserId, userId);

            return PartialView("_UserRelationshipButtons", result.ToVM(userId));
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UnfollowUser(Guid userId) {
            var currentId = userManager.GetUserId(User);
            if (string.IsNullOrEmpty(currentId)) return Unauthorized();
            var currentUserId = Guid.Parse(currentId);

            var result = await followService.UnfollowUserAsync(currentUserId, userId);

            return PartialView("_UserRelationshipButtons", result.ToVM(userId));
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelFollowRequest(Guid userId) {
            var currentId = userManager.GetUserId(User);
            if (string.IsNullOrEmpty(currentId)) return Unauthorized();
            var currentUserId = Guid.Parse(currentId);

            var result = await followService.CancelFollowRequestAsync(currentUserId, userId);

            return PartialView("_UserRelationshipButtons", result.ToVM(userId));
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AcceptFollowRequest(Guid followerUserId) {
            var currentId = userManager.GetUserId(User);
            if (string.IsNullOrEmpty(currentId)) return Unauthorized();
            var currentUserId = Guid.Parse(currentId);

            var result = await followService.AcceptFollowRequestAsync(followerUserId, currentUserId);

            return PartialView("_UserRelationshipButtons", result.ToVM(followerUserId));
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeclineFollowRequest(Guid followerUserId) {
            var currentId = userManager.GetUserId(User);
            if (string.IsNullOrEmpty(currentId)) return Unauthorized();
            var currentUserId = Guid.Parse(currentId);

            var result = await followService.DeclineFollowRequestAsync(followerUserId, currentUserId);

            return PartialView("_UserRelationshipButtons", result.ToVM(followerUserId));
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


