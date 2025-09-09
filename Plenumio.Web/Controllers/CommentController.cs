using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Plenumio.Application.DTOs;
using Plenumio.Application.DTOs.Comments;
using Plenumio.Application.Interfaces;
using Plenumio.Application.Services;
using Plenumio.Core.Entities;
using Plenumio.Core.Enums;
using Plenumio.Web.Mapping;
using Plenumio.Web.Models;
using Plenumio.Web.Models.Comment;

namespace Plenumio.Web.Controllers {
    public class CommentController(ICommentService commentService, UserManager<ApplicationUser> userManager) : Controller {
        public IActionResult Index() {
            return RedirectToAction("Index", "Feed");
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCommentVM model) {

            Guid userId = Guid.Parse(userManager.GetUserId(User)!);

            CreateCommentDto request = new CreateCommentDto(
                model.PostId,
                model.Content,
                model.ParentId
            );

            CommentIdSlugDto response = await commentService.CreateCommentAsync(request, userId);
            
            return Redirect($"/Post/Details/{response.Slug}#comment-{response.Id}");

        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reply(CreateCommentVM model) {
            Guid userId = Guid.Parse(userManager.GetUserId(User)!);

            CreateCommentDto request = new CreateCommentDto(
                model.PostId,
                model.Content,
                model.ParentId
            );
            var newReplyDto = await commentService.CreateReplyAsync(request, userId);

            if (newReplyDto != null) {
                var newReplyViewModel = newReplyDto.ToVM();
                return PartialView("_Comment", newReplyViewModel);
            }
            return NotFound("NotFound");
        }




        [HttpGet]
        public async Task<IActionResult> GetCommentChildren(Guid parentId) {
            IEnumerable<CommentDetailsDto> comments = await commentService.GetRepliesForComment(parentId);

            var commentsVM = comments.Select(c => c.ToVM()).ToList();

            return PartialView("_CommentList", commentsVM);

        }





    }
}
