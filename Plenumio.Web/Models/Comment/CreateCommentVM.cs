namespace Plenumio.Web.Models.Comment {
    public record CreateCommentVM {
        public Guid PostId { get; init; }
        public string Content { get; init; } = string.Empty;
        public Guid? ParentId { get; init; }
    }
}
