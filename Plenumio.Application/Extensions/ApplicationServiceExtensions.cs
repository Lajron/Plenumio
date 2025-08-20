using Microsoft.Extensions.DependencyInjection;
using Plenumio.Application.Interfaces;
using Plenumio.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Extensions {
    public static class ApplicationServiceExtensions {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IPostService, PostService>();

            return services;
        }
    }
}
