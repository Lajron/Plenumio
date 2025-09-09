using Plenumio.Application.DTOs.Posts.Requests;
using Plenumio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Validation {
    internal static class PostExtensions {
        private const int ContentMaxLength = 5000;
        private const int TitleMaxLength = 100;
        public static void ValidateCreatePost(this CreatePostRequest dto) {
            dto.Content.ValidateNotEmpty(nameof(dto.Content)).ValidateMaxLength(ContentMaxLength, nameof(dto.Content));
            dto.Privacy.ValidateNotNull(nameof(dto.Privacy));
            dto.Type.ValidateNotNull(nameof(dto.Type));
            dto.Tags.ValidateNotEmpty(nameof(dto.Tags));

            if (dto.Type == PostType.Standard) dto.Title.ValidateIsEmpty(nameof(dto.Title));
            if (dto.Type == PostType.Article) dto.Title.ValidateNotEmpty(nameof(dto.Title)).ValidateMaxLength(TitleMaxLength, nameof(dto.Title));
        }
    }
}
