using Plenumio.Application.DTOs;
using Plenumio.Application.Interfaces;
using Plenumio.Application.Queries;
using Plenumio.Application.Queries.Tag;
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

        public async Task<IEnumerable<PostFeedDto>> GetPostsByTagName(string name) {
            GetPostsByTagQuery query = new(name);

            return await queryDispatcher.SendAsync<GetPostsByTagQuery, IEnumerable<PostFeedDto>>(query);
        }

        public async Task<IEnumerable<TagDto>> GetAllTags(int skip, int amount) {
            GetAllTagsQuery query = new(skip, amount);

            return await queryDispatcher.SendAsync<GetAllTagsQuery, IEnumerable<TagDto>>(query);
        }
    }
}
