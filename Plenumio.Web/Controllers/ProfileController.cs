using Microsoft.AspNetCore.Mvc;

namespace Plenumio.Web.Controllers {
    public class ProfileController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
