namespace Plenumio.Web.Models.Tag {
    public record TagSummaryVM {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string DisplayedName { get; init; } = string.Empty;
    }
}
