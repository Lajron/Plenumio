using Microsoft.AspNetCore.Mvc;
using Plenumio.Application.DTOs;
using Plenumio.Application.Interfaces;
using Plenumio.Web.Models;

namespace Plenumio.Web.ViewComponents {
    public class CommentFeedViewComponent(IPostService postService) : ViewComponent {
        public async Task<IViewComponentResult> InvokeAsync(Guid postId) {
            IEnumerable<CommentDto> comments = await postService.GetPostCommentsAsync(postId, 3);

            CommentFeedViewModel commentsVM = new CommentFeedViewModel {
                PostId = postId,
                Comments = comments.Select(c => new CommentViewModel {
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
                    HasChildren = false
                })
                .ToList()
            };

            return View(commentsVM);
        }
    }
}
