using Plenumio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs.Common {
    public abstract record BaseFilterDto {
        public SortType Sort { get; init; } = SortType.Newest;
        public int Page { get; init; } = 1;
        public int PageSize { get; init; } = 20;
        public DateTime? FromDate { get; init; }
        public DateTime? ToDate { get; init; }
    }
}
