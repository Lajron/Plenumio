using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Interfaces {
    public interface IQueryHandler<TQuery, TResult> {
        Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
    }
}
