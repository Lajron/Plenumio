using LinqKit;
using Microsoft.EntityFrameworkCore;
using Plenumio.Application.DTOs;
using Plenumio.Application.DTOs.Posts;
using Plenumio.Application.DTOs.Posts.Requests;
using Plenumio.Application.Interfaces;
using Plenumio.Application.Mapping;
using Plenumio.Core.Entities;
using Plenumio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Infrastructure.Queries.PostHandlers {
    public class GetPostDetailsBySlugHandler(ApplicationDbContext db)
        : IQueryHandler<GetPostDetailsBySlugRequest, PostDetailsDto?> {
        public async Task<PostDetailsDto?> HandleAsync(GetPostDetailsBySlugRequest query, CancellationToken cancellationToken = default) {
            return await db.Posts
                .AsExpandable()
                .Where(p => p.Slug == query.Slug)
                .Select(p => PostMapper.ToDetailsDto().Invoke(p, query.ViewerUserId))
                .AsSplitQuery()
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
