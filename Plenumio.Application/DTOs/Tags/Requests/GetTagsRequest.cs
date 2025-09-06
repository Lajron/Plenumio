using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs.Tags.Requests {
    public record GetTagsRequest {
        public TagFilterDto Filters { get; init; } = new();
        public Guid? UserId { get; init; }
    }
}
