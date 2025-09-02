using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Queries.Tag {
    public record GetPostsByTagQuery(
        string Name
    );

    public record GetAllTagsQuery(
        int Skip,
        int Amount
    );
}
