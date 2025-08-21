
using Microsoft.AspNetCore.Mvc;
using Plenumio.Contracts.DTOs;
namespace Plenumio.Web.ViewComponents {
    public class PostFeedViewComponent: ViewComponent {
        public async Task<IViewComponentResult> InvokeAsync() {
            var mockPosts = new List<PostDto> {
                new PostDto(
                Id: 1,
                Description: "Prvi test post o .NET razvoju 🚀",
                Slug: "prvi-test-post",
                PrivacyType: "Public",
                CreatedAt: DateTime.Now.AddDays(-5),
                UpdatedAt: DateTime.Now,
                Author: new UserDto(1, "milos", "https://picsum.photos/50"),
                Tags: new List<TagDto>
                {
                    new TagDto(1, "C#"),
                    new TagDto(2, ".NET")
                },
                Images: new List<ImageDto>
                {
                    new ImageDto(1, "https://picsum.photos/200/300"),
                    new ImageDto(2, "https://picsum.photos/200/301")
                },
                Comments: new List<CommentDto>
                {
                    new CommentDto(1, "Odličan post! Hvala na deljenju 👏", DateTime.Now.AddDays(-4), new UserDto(2, "ana", null), 1),
                    new CommentDto(2, "Možeš li napisati tutorijal? 🙂", DateTime.Now.AddDays(-3), new UserDto(3, "marko", "https://picsum.photos/51"), 1),
                    new CommentDto(3, "Baš korisno, svaka čast!", DateTime.Now.AddDays(-2), new UserDto(4, "jovan", null), 1),
                    new CommentDto(4, "👍", DateTime.Now.AddDays(-1), new UserDto(5, "sofia", "https://picsum.photos/52"), 1)
                },
                CommentsCount: 4,
                LikesCount: 15
                ),
                new PostDto(
                    Id: 2,
                    Description: "Fotografija sa letovanja 🌊",
                    Slug: "fotografija-letovanje",
                    PrivacyType: "FriendsOnly",
                    CreatedAt: DateTime.Now.AddDays(-10),
                    UpdatedAt: DateTime.Now.AddDays(-8),
                    Author: new UserDto(2, "ana", null),
                    Tags: new List<TagDto>
                    {
                        new TagDto(3, "Travel"),
                        new TagDto(4, "Summer")
                    },
                    Images: new List<ImageDto>
                    {
                        new ImageDto(3, "https://picsum.photos/200/302")
                    },
                    Comments: new List<CommentDto>
                    {
                        new CommentDto(5, "Prelepo izgleda 🏖️", DateTime.Now.AddDays(-9), new UserDto(1, "milos", "https://picsum.photos/50"), 2),
                        new CommentDto(6, "Koja plaža je ovo?", DateTime.Now.AddDays(-8), new UserDto(3, "marko", "https://picsum.photos/51"), 2)
                    },
                    CommentsCount: 2,
                    LikesCount: 30
                ),
                new PostDto(
                    Id: 3,
                    Description: "Novi projekat u toku ⚡",
                    Slug: "novi-projekat",
                    PrivacyType: "Private",
                    CreatedAt: DateTime.Now.AddDays(-2),
                    UpdatedAt: DateTime.Now,
                    Author: new UserDto(3, "marko", "https://picsum.photos/51"),
                    Tags: new List<TagDto>
                    {
                        new TagDto(5, "Work"),
                        new TagDto(6, "Coding")
                    },
                    Images: new List<ImageDto>(),
                    Comments: new List<CommentDto>(), 
                    CommentsCount: 0,
                    LikesCount: 5
                )
            };
            
            
            return View(mockPosts);
        }
    }
}
