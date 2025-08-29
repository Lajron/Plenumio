using Microsoft.Extensions.DependencyInjection;
using Plenumio.Application.DTOs;
using Plenumio.Application.Queries;
using Plenumio.Application.Queries.Comment;
using Plenumio.Application.Queries.Feed;
using Plenumio.Application.Queries.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Extensions {
    public static class ApplicationHandlerExtensions {

        public static IServiceCollection AddApplicationHandlers(this IServiceCollection services) {
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();

            services.AddScoped<IQueryHandler<GetPostsForFeedQuery, IEnumerable<PostFeedDto>>, GetPostsForFeedQueryHandler>();
            services.AddScoped<IQueryHandler<GetCommentsForPostQuery, IEnumerable<CommentDto>>, GetCommentsForPostQueryHandler>();
            services.AddScoped<IQueryHandler<GetPostDetailsBySlugQuery, PostDto?>, GetPostDetailsBySlugHandler>();
            services.AddScoped<IQueryHandler<GetRepliesFromCommentQuery, IEnumerable<CommentDto>>, GetRepliesFromCommentQueryHandler>();
            services.AddScoped<IQueryHandler<GetCreatedReplyQuery, CommentDto?>, GetCreatedReplyQueryHandler>();

            return services;
        }
    }
}
