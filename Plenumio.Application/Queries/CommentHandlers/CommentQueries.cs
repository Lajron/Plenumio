using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Queries.Comment {
    public record GetCommentsForPostQuery(Guid Id, int? Top = null);

    public record GetRepliesFromCommentQuery(
        Guid CommentId
    );

    public record GetCreatedReplyQuery(
        Guid CommentId
    );
}
