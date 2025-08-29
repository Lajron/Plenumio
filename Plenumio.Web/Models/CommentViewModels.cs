namespace Plenumio.Web.Models {
    public record CommentViewModel {
        public Guid Id { get; init; }
        public string Content { get; init; } = string.Empty;
        public UserSummaryViewModel User { get; init; } = new();
        public DateTimeOffset CreatedAt { get; init; }
        public DateTimeOffset UpdatedAt { get; init; }
        public bool HasChildren { get; init; }
        public Guid? ParentId { get; init; }
        public List<CommentViewModel> Children { get; init; } = [];
        public Guid PostId { get; init; }
        public int Level { get; init; } = 0;
    }

    public record CommentFeedViewModel {
        public Guid PostId { get; init; }
        public List<CommentViewModel> Comments { get; init; } = [];
    }

    public record CreateCommentViewModel {
        public Guid PostId { get; init; }
        public string Content { get; init; } = string.Empty;
        public Guid? ParentId { get; init; }
    }
}
