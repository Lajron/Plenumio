using Plenumio.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Core.Entities {
    public class Comment : BaseEntity {
        public required string Content { get; set; }

        public Guid? ParentId { get; set; }
        public Comment? Parent { get; set; }
        public ICollection<Comment> Children { get; set; } = [];

        public Guid PostId { get; set; }
        public Post? Post { get; set; }

        public Guid ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
    }
}
