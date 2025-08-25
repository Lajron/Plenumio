using Plenumio.Application.Interfaces;
using Plenumio.Application.DTOs;
using Plenumio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Strategy {
    public class GlobalFeedStrategy : IFeedStrategy {
        public FeedType FeedType => FeedType.Global;

        public async Task<IEnumerable<PostDto>> GetFeedAsync(int? userId) {
            throw new NotImplementedException();
        }
    }
}
