using Plenumio.Application.DTOs.Tags;
using Plenumio.Application.DTOs.Tags.Responses;
using Plenumio.Core.Entities;
using Plenumio.Web.Models.Tag;

namespace Plenumio.Web.Mapping {
    public static class TagMapper {

        public static TagVM ToVM(this GetTagResponse dto) {
            return new TagVM {
                Id = dto.Id,
                Name = dto.Name,
                DisplayedName = dto.DisplayedName,
                PostsCount = dto.PostsCount,
                FollowersCount = dto.FollowersCount,
                FollowButton = new TagFollowButtonVM { TagId = dto.Id, IsFollowing = dto.IsFollowing },
                Parent = dto.Parent?.ToVM(),
                Children = dto.Children.Select(c => c.ToVM())
            };
        }

        public static GetTagResponse ToDto(this TagVM vm) {
            return new GetTagResponse {
                Id = vm.Id,
                Name = vm.Name,
                DisplayedName = vm.DisplayedName,
                PostsCount = vm.PostsCount,
                FollowersCount = vm.FollowersCount,
                IsFollowing = vm.FollowButton.IsFollowing,
                Parent = vm.Parent?.ToDto(),
                Children = vm.Children.Select(c => c.ToDto())
            };
        }

        public static TagSummaryVM ToVM(this TagSummaryDto dto) {
            return new TagSummaryVM {
                Id = dto.Id,
                Name = dto.Name,
                DisplayedName = dto.DisplayedName
            };
        }

        public static TagSummaryDto ToDto(this TagSummaryVM vm) {
            return new TagSummaryDto {
                Id = vm.Id,
                Name = vm.Name,
                DisplayedName = vm.DisplayedName
            };
        }
    }
}
