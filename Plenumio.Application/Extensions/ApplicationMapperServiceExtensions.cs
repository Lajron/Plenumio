using Microsoft.Extensions.DependencyInjection;
using Plenumio.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Extensions {
    public static class ApplicationMapperServiceExtensions {
        public static IServiceCollection AddApplicationMapperProfileServices(this IServiceCollection services) {
            services.AddAutoMapper(cfg => {
                cfg.AddProfile<TagProfile>();
                cfg.AddProfile<PostProfile>();
            });
            return services;
        }
    }
}
