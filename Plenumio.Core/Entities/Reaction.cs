using Plenumio.Core.Entities.Base;
using Plenumio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Core.Entities {
    public class Reaction : BaseIdEntity {
        public required ReactionType Type { get; set; }

        public Guid PostId { get; set; }
        public Post? Post { get; set; }

        public Guid ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
    }
}
