using Plenumio.Application.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs {
    
    public record CommentDto(
       Guid Id,
       string Content,
       UserSummaryDto User,
       DateTimeOffset CreatedAt,
       DateTimeOffset UpdatedAt,
       bool? HasChildren,
       Guid PostId,
       Guid? ParentId
    );

    public record CreateCommentDto(
        Guid PostId,
        string Content,
        Guid? ParentId = null
    );

    public record CommentIdSlugDto(
        Guid Id,
        string Slug
    );

}
