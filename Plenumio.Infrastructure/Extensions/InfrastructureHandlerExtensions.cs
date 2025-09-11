using Microsoft.Extensions.DependencyInjection;
using Plenumio.Application.DTOs;
using Plenumio.Application.DTOs.Comments;
using Plenumio.Application.DTOs.Comments.Requests;
using Plenumio.Application.DTOs.Posts;
using Plenumio.Application.DTOs.Posts.Requests;
using Plenumio.Application.DTOs.Posts.Responses;
using Plenumio.Application.DTOs.Tags.Requests;
using Plenumio.Application.DTOs.Tags.Responses;
using Plenumio.Application.DTOs.Users;
using Plenumio.Application.DTOs.Users.Requests;
using Plenumio.Application.DTOs.Users.Responses;
using Plenumio.Application.Interfaces;
using Plenumio.Infrastructure.Queries;
using Plenumio.Infrastructure.Queries.CommentHandlers;
using Plenumio.Infrastructure.Queries.PostHandlers;
using Plenumio.Infrastructure.Queries.TagHandlers;
using Plenumio.Infrastructure.Queries.UserHandlers;
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

            
            services.AddScoped<IQueryHandler<GetPostDetailsBySlugRequest, PostDetailsDto?>, GetPostDetailsBySlugHandler>();
            services.AddScoped<IQueryHandler<GetPostsRequest, GetPostsResponse>, GetPostsHandler>();

            services.AddScoped<IQueryHandler<GetCommentsForPostRequest, IEnumerable<CommentDetailsDto>>, GetCommentsForPostHandler>();
            services.AddScoped<IQueryHandler<GetByCommentIdRequest, IEnumerable<CommentDetailsDto>>, GetRepliesFromCommentHandler>();
            services.AddScoped<IQueryHandler<GetByCommentIdRequest, CommentDetailsDto?>, GetCreatedReplyHandler>();
            
            services.AddScoped<IQueryHandler<GetTagRequest, GetTagResponse?>, GetTagHandler>();
            services.AddScoped<IQueryHandler<GetTagsRequest, IEnumerable<GetTagResponse>>, GetTagsHandler>();

            services.AddScoped<IQueryHandler<GetUserProfileRequest, GetUserProfileResponse?>, GetUserProfileHandler>();
            services.AddScoped<IQueryHandler<GetUsersRequest, IEnumerable<UserSummaryDto>>, GetUsersHandler>();
            services.AddScoped<IQueryHandler<GetUserRelationshipRequest, GetUserRelationshipResponse>, GetUserRelationshipHandler>();
            
            return services;
        }
    }
}
