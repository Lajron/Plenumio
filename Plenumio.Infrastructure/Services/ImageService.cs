using Microsoft.AspNetCore.Http;
using Plenumio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Infrastructure.Services {
    public class ImageService(string rootPath) : IImageService {
  
        private static readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png" };

        public async Task<string?> SaveImageAsync(ImageFileDto file, string folderPath) {
            string ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!AllowedExtensions.Contains(ext)) return null;

            string uniqueFileName = Guid.NewGuid() + ext;
            string directory = Path.Combine(rootPath, folderPath);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            string path = Path.Combine(directory, uniqueFileName);
            await using var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
            await file.Content.CopyToAsync(fileStream);

            return Path.Combine(folderPath, uniqueFileName).Replace("\\", "/");
        }

        public async Task<IEnumerable<string>> SaveImagesAsync(IEnumerable<ImageFileDto> files, string folderPath) {
            var tasks = files.Select(file => SaveImageAsync(file, folderPath));
            var results = await Task.WhenAll(tasks);
            return results.Where(r => r != null)!;
        }

        public Task DeleteImagesAsync(IEnumerable<string> urls) {

            foreach (var url in urls) {
                string path = Path.Combine(rootPath, url.Replace("/", Path.DirectorySeparatorChar.ToString()));
                if (File.Exists(path))
                    File.Delete(path);
            }
            return Task.CompletedTask;
        }

    }
}
