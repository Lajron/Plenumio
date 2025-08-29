using Microsoft.AspNetCore.Mvc;
using Plenumio.Application.DTOs;
using Plenumio.Application.Interfaces;
using Plenumio.Web.Models;

namespace Plenumio.Web.ViewComponents {
    public class CommentPostViewComponent(IPostService postService) : ViewComponent {
        public async Task<IViewComponentResult> InvokeAsync(Guid postId) {
            IEnumerable<CommentDto> comments = await postService.GetPostCommentsAsync(postId);

            List<CommentViewModel> commentsVM = comments
                .Select(c => new CommentViewModel {
                    Id = c.Id,
                    Content = c.Content,
                    User = new UserSummaryViewModel {
                        Id = c.User.Id,
                        DisplayedName = c.User.DisplayedName,
                        AvatarUrl = c.User.AvatarUrl,
                        IsVerified = c.User.IsVerified
                    },
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt,
                    HasChildren = c.HasChildren ?? false,
                    PostId = c.PostId,
                    ParentId = c.ParentId
                }
            )
            .ToList();

            return View(commentsVM);
        }
    }
}
