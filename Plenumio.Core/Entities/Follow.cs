using Plenumio.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Core.Entities {
    public class Follow : BaseIdEntity {
        public Guid FollowerId { get; set; }
        public ApplicationUser? Follower { get; set; }

        public Guid FollowedId { get; set; }
        public ApplicationUser? Followed { get; set; }
    }
}
