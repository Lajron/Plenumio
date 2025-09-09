using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Plenumio.Web.Controllers {
    public class ErrorController : Controller {

        [HttpGet, HttpPost]
        public IActionResult Handle() {
            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var ex = feature?.Error;

            var status = StatusCodes.Status500InternalServerError;
            var title = "An unexpected error occurred";
            var detail = "Please try again later.";

            if (WantsJson(Request)) {
                return Problem(
                    detail: detail,
                    statusCode: status,
                    title: title,
                    type: $"https://httpstatuses.com/{status}"
                );
            }

            Response.StatusCode = status;
            ViewData["Title"] = title;
            ViewData["Detail"] = detail;
            ViewData["StatusCode"] = status;
            ViewData["TraceId"] = HttpContext.TraceIdentifier;
            return View("Error");
        }

        [HttpGet("{code:int}")]
        public IActionResult StatusRoute(int code) {
            var title = code switch {
                401 => "Unauthorized",
                403 => "Forbidden",
                404 => "Not Found",
                409 => "Conflict",
                500 => "Server Error",
                _ => "Error"
            };

            if (WantsJson(Request)) {
                return Problem(
                    detail: null,
                    statusCode: code,
                    title: title,
                    type: $"https://httpstatuses.com/{code}"
                );
            }

            Response.StatusCode = code;
            ViewData["Title"] = title;
            ViewData["Detail"] = null;
            ViewData["StatusCode"] = code;
            ViewData["TraceId"] = HttpContext.TraceIdentifier;
            return View("Error");
        }

        private static bool WantsJson(HttpRequest req) {
            var isAjax = req.Headers.TryGetValue("X-Requested-With", out var v)
                         && v == "XMLHttpRequest";
            var accept = req.Headers.Accept.ToString();
            return isAjax || accept.Contains("application/json", StringComparison.OrdinalIgnoreCase);
        }
    }
}
