using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs.Common {
    public record InfiniteScrollResponseDto {
        public bool HasMore { get; init; }
        public string? PreviousCursor { get; init; }
        public string? NextCursor { get; init; }
    }
}
