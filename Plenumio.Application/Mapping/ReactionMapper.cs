using Plenumio.Application.DTOs.Reactions;
using Plenumio.Core.Entities;
using Plenumio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Mapping {
    public static class ReactionMapper {

        public static Expression<Func<IGrouping<ReactionType, Reaction>, Guid?, ReactionSummaryDto>> ToSummaryDto() {
            return (rg, userId) => new ReactionSummaryDto {
                Type = rg.Key,
                Count = rg.Count(),
                IsCurrentUserReaction = rg.Any(r => r.ApplicationUserId == userId)
            };
        }
    }
}
