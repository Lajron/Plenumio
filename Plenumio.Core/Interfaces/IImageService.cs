using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Core.Interfaces {
    public record ImageFileDto(Stream Content, string FileName);

    public interface IImageService {
        Task<string?> SaveImageAsync(ImageFileDto file, string folderPath);
        Task<IEnumerable<string>> SaveImagesAsync(IEnumerable<ImageFileDto> files, string folderPath);
        Task DeleteImagesAsync(IEnumerable<string> urls);
    }
}