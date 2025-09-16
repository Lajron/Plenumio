using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Plenumio.Application.DTOs;
using Plenumio.Application.DTOs.Posts;
using Plenumio.Application.DTOs.Posts.Requests;
using Plenumio.Application.DTOs.Posts.Responses;
using Plenumio.Application.Interfaces;
using Plenumio.Application.Services;
using Plenumio.Core.Entities;
using Plenumio.Core.Enums;
using Plenumio.Infrastructure.Utilities;
using Plenumio.Web.Mapping;
using Plenumio.Web.Models;
using Plenumio.Web.Models.Comment;
using Plenumio.Web.Models.Page;
using Plenumio.Web.Models.Post;
using Plenumio.Web.Models.Tag;
using System;

namespace Plenumio.Web.Controllers {
    [Route("[controller]")]
    public class PostController(
            IPostService postService, 
            IImageConverter<IFormFile> imageConverter,
            UserManager<ApplicationUser> userManager
        ) : Controller {

        public async Task<IActionResult> Index(Guid id) {
            var slug = await postService.GetPostSlugByIdAsync(id);

            if (string.IsNullOrEmpty(slug))
                return NotFound(slug);

            return RedirectToAction(nameof(Details), "Post", new { slug });
        }

        [HttpGet("Details/{slug}")]
        public async Task<IActionResult> Details(string slug) {
            string? userId = userManager.GetUserId(User);
            Guid? currentUserId = userId is null ? null : Guid.Parse(userId);

            PostDetailsDto? post = await postService.GetPostBySlugAsync(slug, currentUserId);

            if(post is null)
                return NotFound();

            var postVM = new PostVM {
                Type = post.Type,
                Privacy = post.Privacy,

                Header = new PostHeaderViewModel {
                    PostId = post.Id,
                    Author = post.Author.ToVM(),
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
                    CommentCount = post.CommentsCount,
                    ReactionCount = post.Reactions.Count(),
                    Reactions = []
                },

                Tags = post.Tags.Select(t => t.ToVM()),
                Images = post.Images.Select(i => new ImageViewModel { Id = i.Id, Url = i.Url }).ToList(),

                Comments = []
            };

            var result = new PageVM<PostVM> {
                Content = postVM,
                Title = string.IsNullOrEmpty(post.Title) ? string.Join(" ", post.Content.Split(' ').Take(5)) : post.Title,
                CurrentUserId = currentUserId
            };
            return View(result);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create() {
            var result = new PageVM<CreatePostVM> {
                Content = new CreatePostVM(),
                Title = "Create Post",
                Description = "CREATE POST",
                CurrentUserId = Guid.Parse(userManager.GetUserId(User)!)
            };
            return View(result);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePostVM model, IEnumerable<IFormFile> images) {
            if (model.Type == PostType.Article && string.IsNullOrWhiteSpace(model.Title))
                ModelState.AddModelError(nameof(model.Title), "Title is required for an article.");

            var tags = model.Tags?.Split(' ', StringSplitOptions.RemoveEmptyEntries) ?? [];

            if (tags.Length > 5)
                ModelState.AddModelError(nameof(model.Tags), "You can specify up to 5 tags.");

            if (model.Type == PostType.Standard)
                model.Title = "";

            if (!ModelState.IsValid)
                return View(new PageVM<CreatePostVM> {
                    Content = model,
                    Title = "Create Post",
                    Description = "CREATE POST",
                    CurrentUserId = Guid.Parse(userManager.GetUserId(User)!)
                });

            var userId = Guid.Parse(userManager.GetUserId(User)!);

            var request = new CreatePostRequest {
                Title = model.Title ?? "",
                Content = model.Content,
                Type = model.Type,
                Privacy = model.Privacy,
                Tags = tags
            };

            var imageFileDtos = imageConverter.ToImageFileDtos(images);
            var result = await postService.CreatePostAsync(request, userId, imageFileDtos);

            return RedirectToAction("Details", "Post", new { slug = result.Slug });
        }


        [HttpGet("Details/{slug}/Edit")]
        [Authorize]
        public async Task<IActionResult> Edit(string slug) {
            Guid userId = Guid.Parse(userManager.GetUserId(User)!);

            var post = await postService.GetPostBySlugAsync(slug, userId);
            if (post is null) return NotFound();

            var result = new EditPostVM { 
                CurrentPost = post.ToSummaryVM(),
                NewTitle = post.Title,
                NewContent = post.Content,
                Privacy = post.Privacy,
            };

            return View(result);
        }

        [HttpPost("Details/{slug}/Edit")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string slug, EditPostVM model, IEnumerable<IFormFile> images) {
           
            if (!ModelState.IsValid)
                return View(model);

            var userId = Guid.Parse(userManager.GetUserId(User)!);

            var request = new UpdatePostRequest {
                Id = model.CurrentPost.PostId,
                NewTitle = model.NewTitle,
                NewContent = model.NewContent,
                Privacy = model.Privacy,
                TagsToRemove = model.TagsToRemove,
                ImagesToRemove = model.ImagesToRemove,
                TagsToAdd = model.TagsToAdd?.Split(' ', StringSplitOptions.RemoveEmptyEntries) ?? [],
                NewImagesToUpload = imageConverter.ToImageFileDtos(images)
            };

            await postService.UpdatePostAsync(request, userId);

            return RedirectToAction("Details", "Post", new { slug = model.CurrentPost.Slug });
        }




    }
}
