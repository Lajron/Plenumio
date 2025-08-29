using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Queries {
    public class QueryDispatcher(IServiceProvider serviceProvider): IQueryDispatcher {
        public async Task<TResult> SendAsync<TQuery, TResult>(TQuery query) {
            IQueryHandler<TQuery, TResult> handler = serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();
            return await handler.HandleAsync(query);
        }
    }
}
