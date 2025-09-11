using Microsoft.Extensions.DependencyInjection;
using Plenumio.Core.Interfaces;
using Plenumio.Core.Interfaces.Repositories;
using Plenumio.Infrastructure.Repositories;
using Plenumio.Infrastructure.Persistance;
using Plenumio.Infrastructure.Services;
using Plenumio.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Plenumio.Infrastructure.Utilities.ImageConverters;
using Plenumio.Infrastructure.Utilities;

namespace Plenumio.Infrastructure.Extensions {

    public static class InfrastructureServicesExtensions {
        public static IServiceCollection AddRepositories(this IServiceCollection services) {
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IApplicationUserTagRepository, ApplicationUserTagRepository>();
            services.AddScoped<IFollowRepository, FollowRepository>();

            return services;
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services) {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddEmailSender(this IServiceCollection services) {
            services.AddTransient<IEmailSender, EmailSender>();
            return services;
        }

        public static IServiceCollection AddInfrastructureUtilities(this IServiceCollection services) {
            services.AddScoped<IImageConverter<IFormFile>, FormFileConverter>();
            services.AddScoped<ISlugGenerator, SlugGenerator>();
            return services;
        }


    }
}
