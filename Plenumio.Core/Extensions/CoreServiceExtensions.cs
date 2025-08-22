using Microsoft.Extensions.DependencyInjection;
using Plenumio.Contracts.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Contracts.Extensions {
    public static class CoreServiceExtensions {
        public static IServiceCollection AddCoreAutoMapperProfiles(this IServiceCollection services) {
            services.AddAutoMapper(cfg => {
                cfg.AddProfile<TagProfile>();
                cfg.AddProfile<PostProfile>();
            });
            return services;
        }
    }
}
