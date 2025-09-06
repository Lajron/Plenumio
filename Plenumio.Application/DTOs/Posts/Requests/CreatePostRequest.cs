using Plenumio.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs.Posts.Requests {
    public record CreatePostRequest {
        public string Title { get; init; } = string.Empty;
        public required string Content { get; init; }
        public PostType Type { get; init; }
        public PrivacyType Privacy { get; init; }
        public IEnumerable<string> Tags { get; init; } = [];
    }
}
