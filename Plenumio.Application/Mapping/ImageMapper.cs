using Plenumio.Application.DTOs.Image;
using Plenumio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Mapping {
    public class ImageMapper {

        public static Expression<Func<PostImage, PostImageDto>> ToDto() {
            return img => new PostImageDto {
                Id = img.Id,
                Url = img.Url,
                AltText = img.AltText
            };
        }
    }
}
