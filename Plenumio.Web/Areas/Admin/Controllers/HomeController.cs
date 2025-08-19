using Microsoft.AspNetCore.Mvc;

namespace Plenumio.Web.Areas.Admin.Controllers {
    [Area("Admin")]
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
