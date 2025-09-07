using Plenumio.Core.Entities.Base;
using Plenumio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Core.Entities {
    public class Follow : BaseEntity {
        public Guid FollowerId { get; set; }
        public ApplicationUser? Follower { get; set; }

        public Guid FollowingId { get; set; }
        public ApplicationUser? Following { get; set; }

        public FollowStatus Status { get; set; } = FollowStatus.Pending;
    }
}
