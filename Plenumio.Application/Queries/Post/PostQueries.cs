using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Queries.Post {
    public record GetPostDetailsBySlugQuery(
        string Slug
    );
}
