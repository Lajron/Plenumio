using Plenumio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Core.Entities.Base {
    public interface IPrivacyEntity {
        PrivacyType Privacy { get; set; }

    }
}
