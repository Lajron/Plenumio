using Microsoft.Extensions.DependencyInjection;
using Plenumio.Core.Interfaces;
using Plenumio.Core.Interfaces.Repositories;
using Plenumio.Infrastructure.Repositories;
using Plenumio.Infrastructure.Persistance;
using Plenumio.Infrastructure.Services;

namespace Plenumio.Infrastructure.Extensions {

    public static class InfrastructureServicesExtensions {
        public static IServiceCollection AddRepositories(this IServiceCollection services) {
            services.AddScoped<ITagRepository, TagRepository>();

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


    }
}
