using Plenumio.Core.Entities.Base;
using Plenumio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Core.Entities {
    public class Post: BaseIdEntity {

        public string? Title { get; set; }
        public required string Content { get; set; }
        public required string Slug { get; set; }

        public required PostType Type {  get; set; }
        public required PrivacyType Privacy { get; set; }

        public Guid ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }

        public ICollection<PostImage> Images { get; set; } = [];
        public ICollection<PostTag> PostTag { get; set; } = [];
        public ICollection<Comment> Comments { get; set; } = [];
        public ICollection<Reaction> Reactions { get; set; } = [];

    }
}
