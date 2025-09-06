using Microsoft.Extensions.DependencyInjection;
using Plenumio.Application.DTOs;
using Plenumio.Application.DTOs.Posts.Requests;
using Plenumio.Application.DTOs.Posts.Responses;
using Plenumio.Application.DTOs.Tags.Requests;
using Plenumio.Application.DTOs.Tags.Responses;
using Plenumio.Application.DTOs.Users;
using Plenumio.Application.DTOs.Users.Requests;
using Plenumio.Application.DTOs.Users.Responses;
using Plenumio.Application.Queries;
using Plenumio.Application.Queries.Comment;
using Plenumio.Application.Queries.PostHandlers;
using Plenumio.Application.Queries.TagHandlers;
using Plenumio.Application.Queries.UserHandlers;
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

            services.AddScoped<IQueryHandler<GetCommentsForPostQuery, IEnumerable<CommentDto>>, GetCommentsForPostQueryHandler>();
            
            services.AddScoped<IQueryHandler<GetPostDetailsBySlugQuery, PostDto?>, GetPostDetailsBySlugHandler>();
            services.AddScoped<IQueryHandler<GetPostsRequest, GetPostsResponse>, GetPostsHandler>();

            services.AddScoped<IQueryHandler<GetRepliesFromCommentQuery, IEnumerable<CommentDto>>, GetRepliesFromCommentQueryHandler>();
            services.AddScoped<IQueryHandler<GetCreatedReplyQuery, CommentDto?>, GetCreatedReplyQueryHandler>();
            
            services.AddScoped<IQueryHandler<GetTagRequest, GetTagResponse?>, GetTagHandler>();
            services.AddScoped<IQueryHandler<GetTagsRequest, IEnumerable<GetTagResponse>>, GetTagsHandler>();

            services.AddScoped<IQueryHandler<GetUserProfileRequest, GetUserProfileResponse?>, GetUserProfileHandler>();
            services.AddScoped<IQueryHandler<GetUsersRequest, IEnumerable<UserSummaryDto>>, GetUsersHandler>();

            return services;
        }
    }
}
