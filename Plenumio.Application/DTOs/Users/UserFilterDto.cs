using Plenumio.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs.Users {
    public record UserFilterDto : BaseFilterDto {
        public string SearchTerm { get; init; } = string.Empty;
    }
}
