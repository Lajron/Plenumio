using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Plenumio.Application.DTOs;
using Plenumio.Application.Interfaces;
using Plenumio.Application.Services;
using Plenumio.Core.Entities;
using Plenumio.Core.Enums;
using Plenumio.Web.Models;

namespace Plenumio.Web.Controllers {
    public class CommentController(ICommentService commentService, UserManager<ApplicationUser> userManager) : Controller {
        public IActionResult Index() {
            return RedirectToAction("Index", "Feed");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCommentViewModel model) {

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
        public async Task<IActionResult> Reply(CreateCommentViewModel model) {
            Guid userId = Guid.Parse(userManager.GetUserId(User)!);

            CreateCommentDto request = new CreateCommentDto(
                model.PostId,
                model.Content,
                model.ParentId
            );
            var newReplyDto = await commentService.CreateReplyAsync(request, userId);

            if (newReplyDto != null) {
                var newReplyViewModel = new CommentViewModel {
                    Id = newReplyDto.Id,
                    Content = newReplyDto.Content,
                    User = new UserSummaryViewModel {
                        Id = newReplyDto.User.Id,
                        DisplayedName = newReplyDto.User.DisplayedName,
                        AvatarUrl = newReplyDto.User.AvatarUrl,
                        IsVerified = newReplyDto.User.IsVerified
                    },
                    CreatedAt = newReplyDto.CreatedAt,
                    HasChildren = newReplyDto.HasChildren ?? false,
                    ParentId = model.ParentId,
                    PostId = newReplyDto.PostId
                };
                return PartialView("_Comment", newReplyViewModel);
                }
            return NotFound("NotFound");
        }




        [HttpGet]
        public async Task<IActionResult> GetCommentChildren(Guid parentId) {
            IEnumerable<CommentDto> comments = await commentService.GetRepliesForComment(parentId);

            var commentsVM = comments.Select(c => new CommentViewModel {
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
                ParentId = c.ParentId,
                PostId = c.PostId
            }).ToList();

            return PartialView("_CommentList", commentsVM);

        }





    }
}
