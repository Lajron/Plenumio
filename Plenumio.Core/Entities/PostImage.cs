using Plenumio.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Core.Entities {
    public class PostImage : BaseEntity {
        public required string Url { get; set; }
        public string AltText { get; set; } = string.Empty; 

        public Guid PostId { get; set; }
        public Post? Post { get; set; }
    }
}
