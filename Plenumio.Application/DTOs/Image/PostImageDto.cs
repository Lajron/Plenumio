using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs.Image {
    public record PostImageDto {
        public Guid Id { get; init; }
        public string Url { get; init; } = string.Empty;
        public string AltText { get; init; } = string.Empty;
    }
}
