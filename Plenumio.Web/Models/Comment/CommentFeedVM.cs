namespace Plenumio.Web.Models.Comment {
    public record CommentFeedVM {
        public Guid PostId { get; init; }
        public List<CommentVM> Comments { get; init; } = [];
    }
}
