using Microsoft.AspNetCore.Http;
using Plenumio.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Infrastructure.Utilities.ImageConverters {
    public class FormFileConverter : IImageConverter<IFormFile> {
        public IEnumerable<ImageFileDto> ToImageFileDtos(IEnumerable<IFormFile> files) {
            return files.Select(file => new ImageFileDto(file.OpenReadStream(), file.FileName));
        }
    }
}
