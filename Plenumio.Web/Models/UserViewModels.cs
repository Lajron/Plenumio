namespace Plenumio.Web.Models {
    public record UserViewModel {
        public int Id { get; init; }
        public string Username { get; init; } = string.Empty;
        public string AvatarUrl { get; init; } = string.Empty;
    }
    public record UserSummaryViewModel {
        public Guid Id { get; init; }
        public string DisplayedName { get; init; } = string.Empty;
        public string AvatarUrl { get; init; } = string.Empty;
        public bool IsVerified { get; init; } = false;
    }
}
