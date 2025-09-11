using Plenumio.Application.DTOs;
using Plenumio.Application.DTOs.Tags;
using Plenumio.Application.DTOs.Tags.Requests;
using Plenumio.Application.DTOs.Tags.Responses;
using Plenumio.Application.Interfaces;
using Plenumio.Core.Entities;
using Plenumio.Core.Enums;
using Plenumio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Services {
    public class TagService(IUnitOfWork uof, IQueryDispatcher queryDispatcher) : ITagService {

        public async Task<GetTagResponse?> GetTagAsync(string name, Guid? userId) {
            var query = new GetTagRequest {
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

        public async Task<bool> ToggleFollowAsync(Guid tagId, Guid userId) {
            var aut = await uof.ApplicationUserTags.FindByTagAndUserAsync(tagId, userId);
            bool result;

            if (aut is null) {
                aut = new ApplicationUserTag {
                    ApplicationUserId = userId,
                    TagId = tagId,
                };
                await uof.ApplicationUserTags.AddAsync(aut);
                result = true;
            } else {
                uof.ApplicationUserTags.Remove(aut);
                result = false;
            }
            
            await uof.CompleteAsync();

            return result;
        }
    }
}
