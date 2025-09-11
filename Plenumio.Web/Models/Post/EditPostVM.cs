using Plenumio.Application.Interfaces;
using Plenumio.Core.Enums;
using Plenumio.Web.Models;         // ImageViewModel
using Plenumio.Web.Models.Tag;     // TagVM

namespace Plenumio.Web.Models.Post {
    public record EditPostVM {
        public Guid Id { get; init; }

        // Display-only helpers
        public string Slug { get; init; } = string.Empty;
        public IEnumerable<TagSummaryVM> CurrentTags { get; init; } = [];
        public IEnumerable<ImageViewModel> CurrentImages { get; init; } = [];

        // Editable fields (null means unchanged)
        public string? NewTitle { get; init; }
        public string? NewContent { get; init; }
        public PrivacyType? Privacy { get; init; }

        // Mutations
        public IEnumerable<Guid> TagsToRemove { get; init; } = [];
        public IEnumerable<Guid> ImagesToRemove { get; init; } = [];

        // Space-separated input will bind as a single string element; controller splits
        public IEnumerable<string> TagsToAdd { get; init; } = [];
    }
}
