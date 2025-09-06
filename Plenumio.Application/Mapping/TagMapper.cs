using LinqKit;
using Plenumio.Application.DTOs.Tags;
using Plenumio.Application.DTOs.Tags.Responses;
using Plenumio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Mapping {
    public static class TagMapper {
        public static Expression<Func<Tag, TagSummaryDto>> ToSummaryDto() {
            return tag => new TagSummaryDto {
                Id = tag.Id,
                Name = tag.Name,
                DisplayedName = tag.DisplayedName
            };
        }

        
    }
}
