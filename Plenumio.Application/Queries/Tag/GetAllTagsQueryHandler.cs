using Microsoft.EntityFrameworkCore;
using Plenumio.Application.DTOs;
using Plenumio.Core.Enums;
using Plenumio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Queries.Tag {
    public class GetAllTagsQueryHandler(ApplicationDbContext db)
        : IQueryHandler<GetAllTagsQuery, IEnumerable<TagDto>> {
        public async Task<IEnumerable<TagDto>> HandleAsync(GetAllTagsQuery query, CancellationToken cancellationToken = default) {
            return await db.Tags
                .OrderBy(t => t.Type == TagType.Default)
                .ThenByDescending(t => t.Children.Count)
                .Skip(query.Skip)
                .Take(query.Amount)
                .Select(t => new TagDto(
                        t.Id,
                        t.Name,
                        t.DisplayedName
                    )
                )
                .ToListAsync(cancellationToken);
        }
    }
}
