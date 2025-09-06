using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs.Tags.Requests {
    public record GetTagRequest {
        public string Name { get; init; } = string.Empty;
        public Guid? UserId { get; init; }
    }
}
