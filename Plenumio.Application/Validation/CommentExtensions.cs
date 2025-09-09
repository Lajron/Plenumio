using Plenumio.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Validation {
    internal static class CommentExtensions {
        private const int MaxContentLength = 240;
        public static void ValidateCreateComment(this CreateCommentDto dto) {
            dto.PostId.ValidateNotNull(nameof(dto.PostId));
            dto.ParentId.ValidateIsNull(nameof(dto.ParentId));
            dto.Content.ValidateNotEmpty(nameof(dto.Content)).ValidateMaxLength(MaxContentLength, nameof(dto.Content));
        }

        public static void ValidateCreateReply(this CreateCommentDto dto) {
            dto.PostId.ValidateNotNull(nameof(dto.PostId));
            dto.ParentId.ValidateNotNull(nameof(dto.ParentId));
            dto.Content.ValidateNotEmpty(nameof(dto.Content)).ValidateMaxLength(MaxContentLength, nameof(dto.Content));
        }
    }
}
