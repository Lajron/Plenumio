using Microsoft.AspNetCore.Mvc;
using Plenumio.Contracts.DTOs;

namespace Plenumio.Web.ViewComponents {
    public class RecentlyViewedPostsViewComponent : ViewComponent {
        public async Task<IViewComponentResult> InvokeAsync(int count = 5) {
            var mockPosts = new List<PostDto>
            {
                new PostDto(
                    Id: 1,
                    Description: "Prvi post o .NET razvoju 🚀",
                    Slug: "prvi-post",
                    PrivacyType: "Public",
                    CreatedAt: DateTime.Now.AddDays(-5),
                    UpdatedAt: DateTime.Now,
                    Author: new UserDto(1,"milos","https://picsum.photos/50"),
                    Tags: new List<TagDto> { new TagDto(1,"C#"), new TagDto(2,".NET") },
                    Images: new List<ImageDto> { new ImageDto(1,"https://picsum.photos/100/100") },
                    Comments: new List<CommentDto>
                    {
                        new CommentDto(1,"Super post!", DateTime.Now.AddDays(-4), new UserDto(2,"ana","https://picsum.photos/51"),1)
                    },
                    CommentsCount: 1,
                    LikesCount: 10
                ),
                new PostDto(
                    Id: 2,
                    Description: "Fotografija sa letovanja 🌊",
                    Slug: "fotografija-letovanje",
                    PrivacyType: "FriendsOnly",
                    CreatedAt: DateTime.Now.AddDays(-10),
                    UpdatedAt: DateTime.Now.AddDays(-8),
                    Author: new UserDto(2,"ana","https://picsum.photos/52"),
                    Tags: new List<TagDto> { new TagDto(3,"Travel"), new TagDto(4,"Summer") },
                    Images: new List<ImageDto> { new ImageDto(2,"https://picsum.photos/101/101") },
                    Comments: new List<CommentDto>
                    {
                        new CommentDto(2,"Lepa fotka!", DateTime.Now.AddDays(-9), new UserDto(3,"marko","https://picsum.photos/53"),2)
                    },
                    CommentsCount: 1,
                    LikesCount: 20
                ),
                new PostDto(
                    Id: 3,
                    Description: "Novi projekat u toku ⚡",
                    Slug: "novi-projekat",
                    PrivacyType: "Private",
                    CreatedAt: DateTime.Now.AddDays(-2),
                    UpdatedAt: DateTime.Now,
                    Author: new UserDto(3,"marko","https://picsum.photos/54"),
                    Tags: new List<TagDto> { new TagDto(5,"Work"), new TagDto(6,"Coding") },
                    Images: new List<ImageDto>(),
                    Comments: new List<CommentDto>(),
                    CommentsCount: 0,
                    LikesCount: 5
                ),
                new PostDto(
                    Id: 4,
                    Description: "Travel tips za leto 🏖️",
                    Slug: "travel-tips",
                    PrivacyType: "Public",
                    CreatedAt: DateTime.Now.AddDays(-7),
                    UpdatedAt: DateTime.Now,
                    Author: new UserDto(4,"jovana","https://picsum.photos/55"),
                    Tags: new List<TagDto>(),
                    Images: new List<ImageDto> { new ImageDto(3,"https://picsum.photos/102/102") },
                    Comments: new List<CommentDto>(),
                    CommentsCount: 0,
                    LikesCount: 12
                ),
                new PostDto(
                    Id: 5,
                    Description: "Kuhinja kod kuće 🍳",
                    Slug: "kuhinja-kod-kuce",
                    PrivacyType: "Public",
                    CreatedAt: DateTime.Now.AddDays(-3),
                    UpdatedAt: DateTime.Now,
                    Author: new UserDto(5,"petar","https://picsum.photos/56"),
                    Tags: new List<TagDto>(),
                    Images: new List<ImageDto> { new ImageDto(4,"https://picsum.photos/103/103") },
                    Comments: new List<CommentDto>(),
                    CommentsCount: 0,
                    LikesCount: 8
                ),
            };

            return View("RecentlyViewedPosts", mockPosts.Take(count));
        }
    }
}
