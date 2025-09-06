using Plenumio.Application.DTOs.Posts;
using Plenumio.Web.Models.Filter;

namespace Plenumio.Web.Mapping {
    public static class PostFilterMapper {

        public static PostFilterDto ToDto(this PostFilterVM vm) {
            return new PostFilterDto {
                // Map from the base class (BaseFilterVM) to the base DTO (BaseFilterDto)
                Sort = vm.Sort,
                Page = vm.Page,
                PageSize = vm.PageSize,
                FromDate = vm.FromDate,
                ToDate = vm.ToDate,

                // Map from the derived class (PostFilterVM) to the derived DTO (PostFilterDto)
                Scope = vm.Scope,
                TagId = vm.TagId,
                UserId = vm.UserId,
                Username = vm.Username,
                Search = vm.SearchTerm, 
                Tag = vm.Tag,
                PostType = vm.PostType
            };
        }

        public static PostFilterVM ToVM(this PostFilterDto dto) {
            return new PostFilterVM {
                // Map from the base DTO (BaseFilterDto) to the base VM (BaseFilterVM)
                Sort = dto.Sort,
                Page = dto.Page,
                PageSize = dto.PageSize,
                FromDate = dto.FromDate,
                ToDate = dto.ToDate,

                // Map from the derived DTO (PostFilterDto) to the derived VM (PostFilterVM)
                Scope = dto.Scope,
                TagId = dto.TagId,
                UserId = dto.UserId,
                Username = dto.Username,
                SearchTerm = dto.Search, 
                Tag = dto.Tag,
                PostType = dto.PostType
            };
        }
    }
}
