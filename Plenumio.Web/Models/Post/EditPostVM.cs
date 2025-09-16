using Plenumio.Application.Interfaces;
using Plenumio.Core.Enums;
using Plenumio.Web.Models;      
using Plenumio.Web.Models.Tag;    

namespace Plenumio.Web.Models.Post {
    public record EditPostVM {
        public PostSummaryVM CurrentPost { get; init; } = new();

        public string? NewTitle { get; init; }
        public string? NewContent { get; init; }
        public PrivacyType? Privacy { get; init; }

        public List<Guid> TagsToRemove { get; init; } = [];
        public List<Guid> ImagesToRemove { get; init; } = [];
        public string? TagsToAdd { get; init; }

    }
}
