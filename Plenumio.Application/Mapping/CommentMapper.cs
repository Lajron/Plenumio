using LinqKit;
using Plenumio.Application.DTOs.Comments;
using Plenumio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Mapping {
    public static class CommentMapper {

        public static Expression<Func<Comment, CommentDetailsDto>> ToDetailDto() {
            return comment => new CommentDetailsDto {
                Id = comment.Id,
                PostId = comment.PostId,
                Content = comment.Content,
                Author = UserMapper.ToSummaryDto().Invoke(comment.ApplicationUser!),
                CreatedAt = comment.CreatedAt,
                ParentId = comment.ParentId,
                RepliesCount = comment.Children.Count
            };
        }
    }
}
