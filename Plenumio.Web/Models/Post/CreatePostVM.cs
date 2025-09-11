using Plenumio.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Plenumio.Web.Models.Post {
    public class CreatePostVM {
        public PostType Type { get; set; } = PostType.Standard;

        public string? Title { get; set; }

        [Required(ErrorMessage = "Content can't be empty")]
        [MinLength(1, ErrorMessage = "Content must be at least 1 character long")]
        public string Content { get; set; } = string.Empty;

        public PrivacyType Privacy { get; set; } = PrivacyType.Public;

        [Required(ErrorMessage = "At least one tag is required")]
        [MinLength(2, ErrorMessage = "Tag should minimum have 2 characters")]
        public string Tags { get; set; } = string.Empty;
    }
}
