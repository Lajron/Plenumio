using Plenumio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Core.Entities {
    public class Post: BaseIdEntity {
        public required string Description { get; set; }
        public required string Slug { get; set; }
        public required PrivacyType PrivacyType { get; set; }

        //public required int UserId { get; set; }
        //public User User { get; set; }

        public ICollection<PostTag> PostTag { get; set; } = [];

        //public ICollection<Image> Images { get; set; } = []
    }
}
