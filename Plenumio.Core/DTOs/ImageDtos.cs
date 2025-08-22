using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Contracts.DTOs {
    public record ImageDto(
        int Id,
        string Url
    );
}
