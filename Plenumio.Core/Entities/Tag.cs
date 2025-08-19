
using System.ComponentModel.DataAnnotations;

namespace Plenumio.Core.Entities {
    public class Tag {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Required]
        public required string DisplayedName { get; set; }
        public bool IsCanonical { get; set; } = false;
        public DateTime createdAt { get; set; } = DateTime.UtcNow;

        public int? ParentId { get; set; }
        public Tag? Parent { get; set; }
        public ICollection<Tag> Children { get; set; } = [];
    }
}
