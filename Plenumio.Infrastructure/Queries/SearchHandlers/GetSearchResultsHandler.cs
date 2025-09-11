using Plenumio.Application.DTOs.Search.Requests;
using Plenumio.Application.DTOs.Search.Responses;
using Plenumio.Application.Interfaces;
using Plenumio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Infrastructure.Queries.SearchHandlers {
    public class GetSearchResultsHandler(
        ApplicationDbContext db
        ) : IQueryHandler<GetSearchResultsRequest, GetSearchResultsResponse> {
        public async Task<GetSearchResultsResponse> HandleAsync(GetSearchResultsRequest query, CancellationToken cancellationToken = default) {
            throw new NotImplementedException();
        }
    }
}
