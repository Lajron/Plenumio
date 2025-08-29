using Microsoft.AspNetCore.Mvc;
using Plenumio.Application.DTOs;
using Plenumio.Web.Models.Shared;
using Plenumio.Web.Models.Shared.ViewModels;

namespace Plenumio.Web.ViewComponents {
    public class TestViewComponent : ViewComponent {
        public async Task<IViewComponentResult> InvokeAsync() {
            Console.WriteLine("///////////////////////// TestViewComponent was called.");
            return Content("<h1>Test VC Succeeded!</h1>");
        }
    }
}
