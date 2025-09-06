using Plenumio.Application.DTOs.Tags;
using Plenumio.Core.Entities;
using Plenumio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs {
    public record PostDto(
        Guid Id,
        string Title,
        string Content,
        string Slug,
        PostType Type,
        PrivacyType Privacy,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt,
        OldUserSummaryDto Author,
        IEnumerable<TagSummaryDto> Tags,
        IEnumerable<ImageDto> Images,
        IEnumerable<CommentDto> Comments,
        IEnumerable<ReactionDto> Reactions,
        int CommentCount,
        int ReactionCount
    );

    public record PostFeedDto(
        Guid Id,
        string Title,
        string Content,
        string Slug,
        PostType Type,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt,
        OldUserSummaryDto User,
        IEnumerable<TagSummaryDto> Tags,
        IEnumerable<ImageDto> Images,
        int ReactionCount,
        int CommentCount
    );

    

    public record UpdatePostDto(
        string Description,
        int PrivacyType,
        IEnumerable<int> AddTagIds,
        IEnumerable<int> RemoveTagIds,
        IEnumerable<string> AddImageUrls,
        IEnumerable<string> RemoveImageUrls
    );

    

}
