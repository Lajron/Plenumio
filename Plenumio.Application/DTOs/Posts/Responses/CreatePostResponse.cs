using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs.Posts.Responses {
    public record CreatePostResponse {
        public Guid Id { get; init; }
        public string Slug { get; init; } = string.Empty;
    }
}
