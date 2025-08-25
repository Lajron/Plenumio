namespace Plenumio.Web.Models.Shared {
    public abstract class BaseAspRoute {
        public string? Controller { get; set; }
        public string? Action { get; set; }
        public IDictionary<string, string>? RouteValues { get; set; }
    }
}
