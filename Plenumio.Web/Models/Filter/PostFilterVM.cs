using Plenumio.Core.Enums;

namespace Plenumio.Web.Models.Filter {
    public record PostFilterVM : BaseFilterVM {
        public FeedScope Scope { get; init; } = FeedScope.Personal;

        public Guid? TagId { get; init; }
        public Guid? UserId { get; init; }

        public string? Username { get; init; }
        public string? SearchTerm { get; init; }
        public string? Tag { get; init; }

        public PostType? PostType { get; init; }
    }
}
