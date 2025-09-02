using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NuGet.Protocol;
using Plenumio.Application.DTOs;
using Plenumio.Application.Interfaces;
using Plenumio.Application.Queries.Feed;
using Plenumio.Application.Services;
using Plenumio.Core.Entities;
using Plenumio.Core.Enums;
using Plenumio.Web.Models;
using System.Diagnostics;

namespace Plenumio.Web.Controllers {
    public class FeedController(
            IPostService postService, 
            UserManager<ApplicationUser> userManager
        ) 
        : Controller {

        public async Task<IActionResult> Index(FeedFilterQuery filters) {
            var userId = userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId)) {
                filters = filters with { Scope = FeedScope.Global };
            }

            Guid? currentUserId = string.IsNullOrEmpty(userId) ? null : Guid.Parse(userId);

            var result = await postService.GetPostsAsync(filters, currentUserId);

            

            var postsVM = result.Posts.Select(p => new PostFeedViewModel {
                Type = p.Type,
                Header = new PostHeaderViewModel {
                    PostId = p.Id,
                    Author = new UserSummaryViewModel {
                        Id = p.User.Id,
                        DisplayedName = p.User.DisplayedName,
                        AvatarUrl = p.User.AvatarUrl,
                        IsVerified = p.User.IsVerified
                    },
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    Slug = p.Slug
                },
                Body = new PostContentViewModel {
                    Title = p.Title,
                    Content = p.Content
                },
                Statistics = new PostStatisticsViewModel {
                    PostId = p.Id,
                    CommentCount = p.CommentCount,
                    ReactionCount = p.ReactionCount,
                    Reactions = []
                },
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt,
                Tags = p.Tags.Select(t => new TagViewModel { Name = t.Name, DisplayedName = t.DisplayedName }).ToList(),
                Images = p.Images.Select(i => new ImageViewModel { Url = i.Url }).ToList()
            }).ToList();

            var viewModel = new PageViewModel<PostFeedPageModel> {
                Content = new PostFeedPageModel {
                    Posts = postsVM,
                    Filters = filters
                },
                Title = (filters.Scope == FeedScope.Global) ? "Discover Feed" : "My Feed",
                Pagination = new PaginationViewModel { 
                    PageNumber = filters.Page,
                    PageSize = filters.PageSize,
                    TotalCount = result.TotalCount
                }
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
