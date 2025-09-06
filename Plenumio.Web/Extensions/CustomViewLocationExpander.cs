using Microsoft.AspNetCore.Mvc.Razor;

namespace Plenumio.Web.Extensions {
    public class CustomViewLocationExpander : IViewLocationExpander {
        public void PopulateValues(ViewLocationExpanderContext context) { }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations) {
            var sharedLocations = new[]
            {
                "/Views/Shared/{0}.cshtml",                 
                "/Views/Shared/Layouts/{0}.cshtml",

                "/Views/Shared/Partials/{0}.cshtml",

                "/Views/Shared/Partials/Common/{0}.cshtml",

                "/Views/Shared/Partials/Comments/{0}.cshtml",

                "/Views/Shared/Partials/Feed/{0}.cshtml",

                "/Views/Shared/Partials/Posts/{0}.cshtml",
                "/Views/Shared/Partials/Posts/Post/{0}.cshtml",
                "/Views/Shared/Partials/Posts/Article/{0}.cshtml",

                "/Views/Shared/Partials/Tags/{0}.cshtml",

                "/Views/Shared/Partials/Users/{0}.cshtml",

                "/Views/Shared/Components/{0}.cshtml"
            };

            if (!string.IsNullOrEmpty(context.AreaName)) {
                var areaLocations = new[]
                {
                "/Areas/{2}/Views/Shared/Layouts/{0}.cshtml",
                "/Areas/{2}/Views/Shared/Partials/{0}.cshtml",
                "/Areas/{2}/Views/Shared/Modules/{0}.cshtml",
                "/Areas/{2}/Views/Shared/Modules/Cards/{0}.cshtml",
                "/Areas/{2}/Views/Shared/Components/{0}.cshtml",
                "/Areas/{2}/Views/{1}/{0}.cshtml" 
            };

                return areaLocations.Concat(sharedLocations).Concat(viewLocations);
            }

            return sharedLocations.Concat(viewLocations);
        }
    }
}
