
using Microsoft.AspNetCore.Mvc;
using Plenumio.Application.DTOs;
using Plenumio.Application.Interfaces;
using Plenumio.Core.Enums;
using Plenumio.Web.Models;
namespace Plenumio.Web.ViewComponents {
    public class PostFeedViewComponent(IPostService postService): ViewComponent {
        public async Task<IViewComponentResult> InvokeAsync() {
            IEnumerable<PostFeedDto> posts = await postService.GetFeedPostsAsync();

            var postsVM = posts.Select(p => new PostFeedViewModel {
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

            return View(postsVM);
        }
    }
}
