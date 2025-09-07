using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NuGet.Protocol;
using Plenumio.Application.DTOs;
using Plenumio.Application.DTOs.Posts;
using Plenumio.Application.Interfaces;
using Plenumio.Application.Services;
using Plenumio.Core.Entities;
using Plenumio.Core.Enums;
using Plenumio.Web.Mapping;
using Plenumio.Web.Models;
using Plenumio.Web.Models.Filter;
using Plenumio.Web.Models.Page;
using Plenumio.Web.Models.Tag;
using System.Diagnostics;

namespace Plenumio.Web.Controllers {
    public class FeedController(
            IPostService postService, 
            UserManager<ApplicationUser> userManager
        ) 
        : Controller {

        public async Task<IActionResult> Index(PostFilterVM filtersVM) {
            var userId = userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId)) {
                filtersVM = filtersVM with { Scope = FeedScope.Global };
            }

            Guid? currentUserId = string.IsNullOrEmpty(userId) ? null : Guid.Parse(userId);

            var filtersDto = filtersVM.ToDto();

            var result = await postService.GetPostsAsync(filtersDto, currentUserId);

            

            var postsVM = result.Items.Select(p => new PostFeedViewModel {
                Type = p.Type,
                Header = new PostHeaderViewModel {
                    PostId = p.Id,
                    Author = new UserSummaryViewModel {
                        Id = p.Author.Id,
                        DisplayedName = p.Author.DisplayedName,
                        Username = p.Author.Username,
                        AvatarUrl = p.Author.AvatarUrl,
                        IsVerified = p.Author.IsVerified
                    },
                    CreatedAt = p.CreatedAt,
                    Slug = p.Slug
                },
                Body = new PostContentViewModel {
                    Title = p.Title,
                    Content = p.Content
                },
                Statistics = new PostStatisticsViewModel {
                    PostId = p.Id,
                    CommentCount = p.CommentsCount,
                    ReactionCount = p.Reactions.Sum(r => r.Count),
                    Reactions = []
                },
                CreatedAt = p.CreatedAt,
                Tags = p.Tags.Select(t => new TagVM { Name = t.Name, DisplayedName = t.DisplayedName }).ToList(),
                Images = p.Images.Select(i => new ImageViewModel { Url = i.Url }).ToList()
            }).ToList();

            var viewModel = new PageVM<FeedPageModel> {
                Content = new FeedPageModel {
                    Posts = postsVM,
                    Filters = filtersVM
                },
                Title = (filtersVM.Scope == FeedScope.Global) ? "Discover Feed" : "My Feed",
                CurrentUserId = currentUserId
            };

            return View(viewModel);
        }


        public IActionResult Privacy() {
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
