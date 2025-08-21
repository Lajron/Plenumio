using Microsoft.Extensions.DependencyInjection;
using Plenumio.Application.Interfaces;
using Plenumio.Application.Services;
using Plenumio.Application.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Extensions {

    public static class FeedStrategyServicesExtension {
        public static IServiceCollection AddFeedStrategyServices(this IServiceCollection services) {
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IFeedStrategyFactory, FeedStrategyFactory>();

            return services;
        }
    }
}
