using Microsoft.AspNetCore.Http;
using Plenumio.Application.DTOs;
using Plenumio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Utilities {
    public static class ImageConverter {

        public static IEnumerable<ImageFileDto> ToImageFileDtos(IEnumerable<IFormFile> files) {
            return files.Select(file => new ImageFileDto(file.OpenReadStream(), file.FileName));
        }
    }
}
