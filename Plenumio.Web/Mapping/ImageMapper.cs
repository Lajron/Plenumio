using Plenumio.Application.DTOs.Image;
using Plenumio.Web.Models;

namespace Plenumio.Web.Mapping {
    public static class ImageMapper {

        public static ImageViewModel ToVM(this PostImageDto dto) {
            return new ImageViewModel { Id = dto.Id, Url = dto.Url };
        }
    }
}
