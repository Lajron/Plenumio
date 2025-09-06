using Plenumio.Application.DTOs;
using Plenumio.Application.DTOs.Tags;
using Plenumio.Application.DTOs.Tags.Requests;
using Plenumio.Application.DTOs.Tags.Responses;
using Plenumio.Application.Interfaces;
using Plenumio.Application.Queries;
using Plenumio.Application.Queries.TagHandlers;
using Plenumio.Core.Enums;
using Plenumio.Core.Interfaces;
using Plenumio.Infrastructure.Data;
using Plenumio.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Services {
    public class TagService(IUnitOfWork uof, IQueryDispatcher queryDispatcher): ITagService {   

        public async Task<GetTagResponse?> GetTagAsync(string name, Guid? userId) {
            GetTagRequest query = new() {
                Name = name,
                UserId = userId
            };

            return await queryDispatcher.SendAsync<GetTagRequest, GetTagResponse?>(query);
        }

        public async Task<IEnumerable<GetTagResponse>> GetTagsAsync(TagFilterDto filters, Guid? userId) {
            var query = new GetTagsRequest {
                Filters = filters,
                UserId = userId
            };

            return await queryDispatcher.SendAsync<GetTagsRequest, IEnumerable<GetTagResponse>>(query);
        }

        public async Task<IEnumerable<GetTagResponse>> GetAllTagsAsync(TagFilterDto filters, Guid? userId) {
            var query = new GetTagsRequest {
                Filters = filters with { SearchTerm = "" },
                UserId = userId
            };

            return await queryDispatcher.SendAsync<GetTagsRequest, IEnumerable<GetTagResponse>>(query);
        }
    }
}
