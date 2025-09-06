using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Plenumio.Application.DTOs.Users.Requests;
using Plenumio.Application.Interfaces;
using Plenumio.Application.Services;

namespace Plenumio.Web.Controllers {
    public class RegisterController(
            IUserService userService
        ) : Controller {

        public IActionResult Index(string? returnUrl = null) {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(RegisterUserRequest model, string? returnUrl = null) {
            if (!ModelState.IsValid)
                return View(model);

            try {
                var user = await userService.CreateUserAsync(model);

                var loginRequest = new LoginUserRequest {
                    Username = user.Username,
                    Password = model.Password,
                    RememberMe = false
                };

                var loginResult = await userService.LoginUserAsync(loginRequest);

                if (loginResult != null) {
                    if (string.IsNullOrEmpty(returnUrl))
                        return RedirectToAction("Feed", "Index");

                    return Redirect(returnUrl);
                }

                ModelState.AddModelError(string.Empty, "Registration succeeded, but login failed. Please try to log in.");
                return View(model);

            } catch (ApplicationException ex) {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }
    }
}
