using Plenumio.Application.DTOs;
using Plenumio.Application.Queries.Feed;
using Plenumio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Queries.Post {
    public record GetPostDetailsBySlugQuery(
        string Slug
    );

    public record PostsQueryResult(
        List<PostFeedDto> Posts, 
        int TotalCount
    );

    public record GetPostsQuery(
        FeedFilterQuery Filters,
        Guid? UserId
    );

    public record GetPersonalFeedQuery(
        FeedFilterQuery Filters,
        Guid UserId
    );

    public record GetGlobalFeedQuery(
        FeedFilterQuery Filters,
        Guid? UserId = null
    );

    public record GetUserPostsQuery(
        Guid TargetUserId,
        FeedFilterQuery Filters,
        Guid? ViewerUserId = null
    );

    public record SearchPostsQuery(
        FeedFilterQuery Filters,
        Guid? ViewerUserId = null
    );

}
