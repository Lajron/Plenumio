using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plenumio.Application.DTOs.Users.Requests;
using Plenumio.Application.Interfaces;
using Plenumio.Application.Services;

namespace Plenumio.Web.Controllers {
    public class LoginController(
            IUserService userService
        ) : Controller {
        public IActionResult Index(string? returnUrl = null) {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginUserRequest model, string? returnUrl = null) {
            if (!ModelState.IsValid) {
                return View(model);
            }

            var result = await userService.LoginUserAsync(model);

            if (result == null) {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }

            if (string.IsNullOrEmpty(returnUrl))
                return RedirectToAction("Feed", "Index");

            return Redirect(returnUrl);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout() {
            await userService.LogoutAsync();
            return RedirectToAction("Index", "Feed");
        }
    }
}
