using Plenumio.Web.Models.Profile;

namespace Plenumio.Web.Models.Comment {
    public record CommentVM {
        public Guid Id { get; init; }
        public string Content { get; init; } = string.Empty;
        public UserSummaryVM User { get; init; } = new();
        public DateTimeOffset CreatedAt { get; init; }
        public DateTimeOffset UpdatedAt { get; init; }
        public bool HasChildren { get; init; }
        public int RepliesCount { get; init; }
        public Guid? ParentId { get; init; }
        public List<CommentVM> Children { get; init; } = [];
        public Guid PostId { get; init; }
    }
}
