using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Plenumio.Core.Entities;
using Plenumio.Infrastructure.Data;

namespace Plenumio.Web.Areas.Admin.Controllers {
    [Area("Admin")]
    public class TagController(ApplicationDbContext db) : Controller {

        public async Task<IActionResult> Index() {
            List<Tag> tags = await db.Tags.ToListAsync();
            return View(tags);
        }
    }
}
