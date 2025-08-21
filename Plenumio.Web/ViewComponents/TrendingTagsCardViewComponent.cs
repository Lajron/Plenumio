using Microsoft.AspNetCore.Mvc;
using Plenumio.Contracts.DTOs;

namespace Plenumio.Web.ViewComponents {
    public class TrendingTagsCardViewComponent: ViewComponent {
        public async Task<IViewComponentResult> InvokeAsync() {
            var tags = new List<TagDto>
            {
                new TagDto(1, "C#"),
                new TagDto(2, ".NET"),
                new TagDto(3, "MVC"),
                new TagDto(4, "Blazor"),
                new TagDto(5, "ASP.NET")
            };

            return View(tags);
        }
    } 
}
