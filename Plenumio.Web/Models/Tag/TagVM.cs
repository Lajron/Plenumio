namespace Plenumio.Web.Models.Tag {
    public record TagVM {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string DisplayedName { get; init; } = string.Empty;
        public int PostsCount { get; init; }
        public int FollowersCount { get; init; }
        public bool IsFollowing { get; init; }
        public TagSummaryVM? Parent { get; init; }
        public IEnumerable<TagSummaryVM> Children { get; init; } = [];
    }
}
