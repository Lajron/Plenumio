using Plenumio.Application.DTOs;
using Plenumio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Interfaces {
    public interface IFeedStrategy {
        FeedType FeedType { get; }
        Task<IEnumerable<PostDto>> GetFeedAsync(int? userId);
    }
}
