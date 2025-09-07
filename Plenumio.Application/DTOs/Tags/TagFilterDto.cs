using Plenumio.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs.Tags {
    public record TagFilterDto : BaseFilterDto {
        public string SearchTerm { get; init; } = string.Empty;
        public Guid? UserId { get; init; }

        }
}
