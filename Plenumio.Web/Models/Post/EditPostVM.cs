using Plenumio.Core.Enums;

namespace Plenumio.Web.Models.Post {
    public record EditPostVM {
        public Guid Id { get; init; }
        public PostType Type { get; init; } = PostType.Standard;
        public string? Title { get; init; }
        public string Content { get; init; } = string.Empty;
        public PrivacyType Privacy { get; init; } = PrivacyType.Public;
        public List<string> Tags { get; init; } = [];

        public List<string> ExistingImageUrls { get; init; } = [];


    }
}
