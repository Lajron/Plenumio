using Plenumio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Interfaces {
    public interface IFeedStrategyFactory {
        IFeedStrategy GetStrategy(FeedType feedType);
    }
}
