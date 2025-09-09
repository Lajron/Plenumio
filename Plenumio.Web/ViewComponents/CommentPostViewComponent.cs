using Microsoft.AspNetCore.Mvc;
using Plenumio.Application.DTOs;
using Plenumio.Application.DTOs.Comments;
using Plenumio.Application.Interfaces;
using Plenumio.Web.Mapping;
using Plenumio.Web.Models;
using Plenumio.Web.Models.Comment;

namespace Plenumio.Web.ViewComponents {
    public class CommentPostViewComponent(IPostService postService) : ViewComponent {
        public async Task<IViewComponentResult> InvokeAsync(Guid postId) {
            IEnumerable<CommentDetailsDto> comments = await postService.GetPostCommentsAsync(postId);

            List<CommentVM> commentsVM = comments
                .Select(c => c.ToVM())
                .ToList();

            return View(commentsVM);
        }
    }
}
