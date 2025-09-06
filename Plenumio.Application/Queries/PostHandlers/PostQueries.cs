using Plenumio.Application.DTOs;
using Plenumio.Application.DTOs.Posts;
using Plenumio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Queries.PostHandlers {
    public record GetPostDetailsBySlugQuery(
        string Slug
    );

    public record GetPersonalFeedQuery(
        PostFilterDto Filters,
        Guid UserId
    );

    public record GetGlobalFeedQuery(
        PostFilterDto Filters,
        Guid? UserId = null
    );

    public record GetUserPostsQuery(
        Guid TargetUserId,
        PostFilterDto Filters,
        Guid? ViewerUserId = null
    );

    public record SearchPostsQuery(
        PostFilterDto Filters,
        Guid? ViewerUserId = null
    );

}
