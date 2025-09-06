using Plenumio.Application.DTOs.Common;
using Plenumio.Application.DTOs.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs.Posts.Responses {
    public record GetPostsResponse : InfiniteScrollResponseDto {
        public List<PostDetailsDto> Items { get; init; } = [];
}
}
