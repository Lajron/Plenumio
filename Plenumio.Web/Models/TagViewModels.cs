namespace Plenumio.Web.Models {
    public record TagViewModel {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string DisplayedName { get; init; } = string.Empty;
    }
}
