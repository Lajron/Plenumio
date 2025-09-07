using Microsoft.AspNetCore.Mvc;
using Plenumio.Application.DTOs.Posts;
using Plenumio.Application.DTOs.Users;
using Plenumio.Application.Interfaces;
using Plenumio.Web.Mapping;
using Plenumio.Web.Models;
using Plenumio.Web.Models.Filter;
using Plenumio.Web.Models.Page;
using Plenumio.Web.Models.Tag;

namespace Plenumio.Web.ViewComponents {
    public class PostsViewComponent(
        IPostService postService
        ) : ViewComponent {
        public async Task<IViewComponentResult> InvokeAsync(PostFilterVM filters, Guid? currentUserId) {
            var filtersDto = filters.ToDto();
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////////");
            var posts = await postService.GetPostsAsync(filtersDto, currentUserId);

            var postsVM = posts.Items.Select(p => new PostFeedViewModel {
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

            var content = new FeedPageModel {
                Posts = postsVM,
                Filters = filters
            };

            return View(content);
        }
    }
}
