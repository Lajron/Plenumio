using Plenumio.Application.DTOs.Comments;
using Plenumio.Web.Models.Comment;

namespace Plenumio.Web.Mapping {
    public static class CommentMapper {

        public static CommentVM ToVM(this CommentDetailsDto dto) {
            return new CommentVM {
                Id = dto.Id,
                Content = dto.Content,
                User = dto.Author.ToVM(),
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.CreatedAt,
                HasChildren = dto.RepliesCount > 0,
                RepliesCount = dto.RepliesCount,
                ParentId = dto.ParentId,
                Children = [],
                PostId = dto.PostId
            };
        }
    }
}
