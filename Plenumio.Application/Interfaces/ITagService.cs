using Plenumio.Application.DTOs;
using Plenumio.Application.DTOs.Tags;
using Plenumio.Application.DTOs.Tags.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Interfaces {
    public interface ITagService {

        Task<GetTagResponse?> GetTagAsync(string name, Guid? userId);
        Task<IEnumerable<GetTagResponse>> GetTagsAsync(TagFilterDto filters, Guid? userId);
        Task<IEnumerable<GetTagResponse>> GetAllTagsAsync(TagFilterDto filters, Guid? userId);

        Task<bool> ToggleFollowAsync(Guid tagId, Guid userId);

    }
}
