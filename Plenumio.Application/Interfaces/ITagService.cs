using Plenumio.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Interfaces {
    public interface ITagService {
        Task<IEnumerable<PostFeedDto>> GetPostsByTagName(string name);
        Task<IEnumerable<TagDto>> GetAllTags(int skip, int amount);
    }
}
