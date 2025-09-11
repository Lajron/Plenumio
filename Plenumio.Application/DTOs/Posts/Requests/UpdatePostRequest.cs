using Microsoft.AspNetCore.Http;
using Plenumio.Application.Interfaces;
using Plenumio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs.Posts.Requests {
    public record UpdatePostRequest {
        public Guid Id { get; init; }
        public string? NewTitle { get; init; }
        public string? NewContent { get; init; }
        public PrivacyType? Privacy { get; init; }
        public IEnumerable<Guid> TagsToRemove { get; init; } = [];
        public IEnumerable<Guid> ImagesToRemove { get; init; } = [];
        public IEnumerable<ImageFileDto> NewImagesToUpload { get; init; } = []; 
        public IEnumerable<string> TagsToAdd { get; init; } = []; 
    }
}
