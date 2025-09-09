using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs.Comments.Requests {
    public record GetByCommentIdRequest {
        public Guid CommentId { get; init; }
    }
}
