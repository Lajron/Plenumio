using Plenumio.Application.Interfaces;
using Plenumio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Strategy {
    public class FeedStrategyFactory(IEnumerable<IFeedStrategy> strategies) : IFeedStrategyFactory {
        Dictionary<FeedType, IFeedStrategy> dictStrategies = strategies.ToDictionary(s => s.FeedType, s => s);

        public IFeedStrategy GetStrategy(FeedType feedType) {
            return dictStrategies[feedType];
        }
    }
}
