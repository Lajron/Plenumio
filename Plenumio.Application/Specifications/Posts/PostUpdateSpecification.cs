using Plenumio.Core.Entities;
using Plenumio.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Specifications.Posts {
    public class PostUpdateSpecification : BaseSpecification<Post> {
        public PostUpdateSpecification(
            Guid postId,
            Guid userId,
            bool includeImages = false,
            bool includeTags = false
        ) : base(p => p.Id == postId && p.ApplicationUserId == userId) {

            if (includeImages) {
                AddInclude(p => p.Images);
            }
            if (includeTags) {
                AddInclude(p => p.PostTag);
            }
        }
    }
}
