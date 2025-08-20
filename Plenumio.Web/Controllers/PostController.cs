using Microsoft.AspNetCore.Mvc;

namespace Plenumio.Web.Controllers {
    public class PostController : Controller {
        private readonly ILogger<HomeController> _logger;

        public PostController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            return View();
        }
    }
}
