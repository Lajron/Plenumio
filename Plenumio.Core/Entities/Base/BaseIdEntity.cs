using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Core.Entities.Base {
    public class BaseIdEntity: BaseEntity {
        [Key]
        public Guid Id { get; set; }
    }
}
