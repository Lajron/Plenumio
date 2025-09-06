using LinqKit;
using Plenumio.Application.DTOs.Image;
using Plenumio.Application.DTOs.Posts;
using Plenumio.Application.DTOs.Reactions;
using Plenumio.Application.DTOs.Tags;
using Plenumio.Application.DTOs.Users;
using Plenumio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Mapping {
    public static class PostMapper {
        public static Expression<Func<Post, Guid?, PostDetailsDto>> ToDetailsDto() {
            return (post, userId) => new PostDetailsDto {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Slug = post.Slug,
                Type = post.Type,
                Author = UserMapper.ToSummaryDto().Invoke(post.ApplicationUser!),
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt,
                CommentsCount = post.Comments.Count,
                Tags = post.PostTag.Select(pt => 
                    TagMapper.ToSummaryDto().Invoke(pt.Tag!)
                ), 
                Reactions = post.Reactions
                    .GroupBy(r => r.Type)
                    .Select(rg => 
                        ReactionMapper.ToSummaryDto().Invoke(rg, userId)
                ),
                Images = post.Images.Select(img => 
                    ImageMapper.ToDto().Invoke(img)
                )
            };
        }

    }
}
