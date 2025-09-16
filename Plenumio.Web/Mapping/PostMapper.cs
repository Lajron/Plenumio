using Plenumio.Application.DTOs.Posts;
using Plenumio.Web.Models;

namespace Plenumio.Web.Mapping {
    public static class PostMapper {

        public static PostSummaryVM ToSummaryVM(this PostDetailsDto dto) {
            return new PostSummaryVM {
                PostId = dto.Id,
                Slug = dto.Slug,
                Title = dto.Title,
                Content = dto.Content,
                Tags = dto.Tags.Select(t => t.ToVM()),
                Images = dto.Images.Select(i => i.ToVM()),
                Privacy = dto.Privacy,
                Type = dto.Type
            };
        }
    }
}
