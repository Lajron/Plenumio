using Microsoft.AspNetCore.Identity;
using Plenumio.Core.Entities.Base;
using Plenumio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Core.Entities {
    public class ApplicationUser: IdentityUser<Guid>, IAuditableEntity, IPrivacyEntity {

        public required string DisplayedName { get; set; }
        public string Description { get; set; } = string.Empty;
        public string AvatarUrl { get; set; } = string.Empty;
        public string BackgroundUrl { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public bool IsVerified { get; set; } = false;
        public PrivacyType Privacy { get; set; } = PrivacyType.Public;

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
        public bool IsDeleted { get; set; } = false;

        public ICollection<Post> Posts { get; set; } = [];

        public ICollection<Comment> Comments { get; set; } = [];

        public ICollection<ApplicationUserTag> UserTags { get; set; } = [];

        public ICollection<Reaction> Reactions { get; set; } = [];

        public ICollection<Follow> Following { get; set; } = [];
        public ICollection<Follow> Followers { get; set; } = [];
    }
}
