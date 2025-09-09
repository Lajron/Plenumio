using Plenumio.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Plenumio.Web.Models.Post {
    public class CreatePostVM {
        public PostType Type { get; set; } = PostType.Standard;

        public string? Title { get; set; }

        [Required(ErrorMessage = "Content can't be empty")]
        public string Content { get; set; } = string.Empty;

        public PrivacyType Privacy { get; set; } = PrivacyType.Public;

        [Required(ErrorMessage = "At least one tag is required")]
        public string Tags { get; set; } = string.Empty;
    }
}
