using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Plenumio.Application.DTOs;
using Plenumio.Application.Interfaces;
using Plenumio.Application.Services;
using Plenumio.Application.Utilities;
using Plenumio.Core.Entities;
using Plenumio.Core.Enums;
using Plenumio.Web.Models;

namespace Plenumio.Web.Controllers {
    public class PostController(IPostService postService, UserManager<ApplicationUser> userManager) : Controller {

        public async Task<IActionResult> Index(Guid id) {
            var feedPosts = await postService.GetFeedPostsAsync();
            return Ok(feedPosts);
        }

        [HttpGet("Post/Details/{slug}")]
        public async Task<IActionResult> Details(string slug) {
            PostDto? post = await postService.GetPostBySlugAsync(slug);

            if(post is null)
                return NotFound();

            PostViewModel postVM = new PostViewModel {
                Type = post.Type,
                Privacy = post.Privacy,

                Header = new PostHeaderViewModel {
                    PostId = post.Id,
                    Author = new UserSummaryViewModel {
                        Id = post.Author.Id,
                        DisplayedName = post.Author.DisplayedName,
                        AvatarUrl = post.Author.AvatarUrl,
                        IsVerified = post.Author.IsVerified
                    },
                    CreatedAt = post.CreatedAt,
                    UpdatedAt = post.UpdatedAt,
                    Slug = post.Slug
                },

                Body = new PostContentViewModel {
                    Title = post.Title,
                    Content = post.Content
                },

                Statistics = new PostStatisticsViewModel {
                    PostId = post.Id,
                    CommentCount = post.CommentCount,
                    ReactionCount = post.ReactionCount,
                    Reactions = post.Reactions.Select(r => new ReactionViewModel { Name = r.Name }).ToList()
                },

                Tags = post.Tags.Select(t => new TagViewModel { Id = t.Id, Name = t.Name }).ToList(),
                Images = post.Images.Select(i => new ImageViewModel { Id = i.Id, Url = i.Url }).ToList(),

                Comments = post.Comments.Select(c => new CommentViewModel {
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
                    HasChildren = c.HasChildren ?? false
                }).ToList()
            };

            return View(postVM);
        }

        public IActionResult CreatePost() {
            return View(new CreatePostViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost(CreatePostViewModel model, IEnumerable<IFormFile> images) {
            if (!ModelState.IsValid) {
                return View(model);
            }

            var userId = Guid.Parse(userManager.GetUserId(User)!);

            var request = new CreatePostDto(
                "", // empty because standard post has no title
                model.Content,
                PostType.Standard,
                model.Privacy,
                model.Tags
            );

            var imageFileDtos = ImageConverter.ToImageFileDtos(images);

            PostIdSlugDto result = await postService.CreatePostAsync(request, userId, imageFileDtos);

            
            return RedirectToAction("Details", "Post", new { slug = result.Slug });
        }

        public IActionResult CreateArticle() {
            return View(new CreateArticleViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateArticle(CreateArticleViewModel model, IEnumerable<IFormFile> images) {
            if (!ModelState.IsValid)
                return View(model);

            var userId = Guid.Parse(userManager.GetUserId(User)!);

            // Map ViewModel to DTO
            var dto = new CreatePostDto(
                Title: model.Title,
                Content: model.Content,
                Type: PostType.Article, // Article type
                Privacy: model.Privacy,
                Tags: model.Tags
            );

            var imageFileDtos = ImageConverter.ToImageFileDtos(images);

            PostIdSlugDto post = await postService.CreatePostAsync(dto, userId, imageFileDtos);

            return RedirectToAction("Index", "Feed");
        }
    }
}
