using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs.Posts.Requests {
    public record GetPostDetailsBySlugRequest {
        public string Slug { get; init; } = string.Empty;
        public Guid? ViewerUserId { get; init; }
    }
}
