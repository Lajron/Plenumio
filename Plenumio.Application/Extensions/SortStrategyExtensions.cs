using Microsoft.Extensions.DependencyInjection;
using Plenumio.Application.Interfaces;
using Plenumio.Application.Services;
using Plenumio.Application.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plenumio.Core.Entities;

namespace Plenumio.Application.Extensions {

    public static class SortStrategyExtensions {
        public static IServiceCollection AddSortStrategyServices(this IServiceCollection services) {
            services.AddScoped<ISortStrategy<Post>, PostSortStrategy>();
            services.AddScoped<ISortStrategy<ApplicationUser>, UserSortStrategy>();

            return services;
        }
    }
}
