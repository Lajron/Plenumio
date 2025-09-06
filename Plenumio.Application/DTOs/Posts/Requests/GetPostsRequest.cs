using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs.Posts.Requests {
    public record GetPostsRequest {
        public PostFilterDto Filters { get; init; } = new();
        public Guid? UserId { get; init; }
    }
}
