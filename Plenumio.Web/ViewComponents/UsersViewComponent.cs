using Microsoft.AspNetCore.Mvc;
using Plenumio.Application.DTOs.Tags;
using Plenumio.Application.DTOs.Users;
using Plenumio.Application.Interfaces;
using Plenumio.Application.Services;
using Plenumio.Web.Mapping;
using Plenumio.Web.Models.Filter;
using Plenumio.Web.Models.Page;
using Plenumio.Web.Models.Profile;
using Plenumio.Web.Models.Tag;

namespace Plenumio.Web.ViewComponents {
    public class UsersViewComponent(
        IUserService userService
        ) : ViewComponent {
        public async Task<IViewComponentResult> InvokeAsync(UserFilterVM filters, Guid? currentUserId) {
            var userFilters = new UserFilterDto {
                SearchTerm = filters.SearchTerm,
                PageSize = filters.PageSize
            };
            var users = await userService.GetUsersAsync(userFilters, currentUserId);

            var usersVM = users.Select(u => u.ToVM());

            var result = new PageVM<IEnumerable<UserSummaryVM>> {
                Content = usersVM,
                Title = filters.SearchTerm
            };

            return View(result);
        }
    }
}
