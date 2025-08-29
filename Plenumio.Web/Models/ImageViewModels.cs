namespace Plenumio.Web.Models {
    public record ImageViewModel {
        public Guid Id { get; init; }
        public string Url { get; init; } = string.Empty;
    }
}
