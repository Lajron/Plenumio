namespace Plenumio.Web.Models.Tag {
    public record TagFollowButtonVM {
        public Guid TagId { get; init; }
        public bool IsFollowing { get; init; }
    }
}
