using Plenumio.Application.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs.Comments {
    public record CommentSummaryDto {
        public Guid Id { get; init; }
        public string Content { get; init; } = string.Empty;
        public UserSummaryDto Author { get; init; } = new();
        public DateTimeOffset CreatedAt { get; init; }
    }
}
