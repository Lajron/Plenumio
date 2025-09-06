namespace Plenumio.Web.Models.Profile {
    public record UserSummaryVM {
        public Guid Id { get; init; }
        public string DisplayedName { get; init; } = string.Empty;
        public string Username { get; init; } = string.Empty;
        public string AvatarUrl { get; init; } = string.Empty;
        public bool IsVerified { get; init; }
    }
}
