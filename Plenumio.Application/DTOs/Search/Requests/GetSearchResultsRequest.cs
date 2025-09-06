using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs.Search.Requests {
    public record GetSearchResultsRequest {
        public string? Query { get; init; }
    }
}
