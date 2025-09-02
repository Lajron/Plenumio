
using Plenumio.Core.Entities.Base;
using Plenumio.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Plenumio.Core.Entities {
    public class Tag: BaseEntity {

        public required string Name { get; set; }
        public required string DisplayedName { get; set; }
        public TagType Type { get; set; } = TagType.User;

        public Guid? ParentId { get; set; }
        public Tag? Parent { get; set; }
        public ICollection<Tag> Children { get; set; } = [];

        public ICollection<PostTag> PostTag { get; set; } = [];
        public ICollection<ApplicationUserTag> UserTags { get; set; } = [];

    }
}
