using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs {
    public record PostDto(
        int Id,
        string Description,
        string Slug,
        string PrivacyType,
        DateTime CreatedAt,
        DateTime UpdatedAt,
        UserDto Author,
        IEnumerable<TagDto> Tags,
        IEnumerable<ImageDto> Images,
        IEnumerable<CommentDto> Comments,
        IEnumerable<ReactionDto> Reactions,
        int LikesCount
    );

    public record CreatePostDto(
        string Description,
        int PrivacyType,
        IEnumerable<int> TagIds,
        IEnumerable<string> ImageUrls
    );

    public record UpdatePostDto(
        string Description,
        int PrivacyType,
        IEnumerable<int> AddTagIds,
        IEnumerable<int> RemoveTagIds,
        IEnumerable<string> AddImageUrls,
        IEnumerable<string> RemoveImageUrls
    );

    public record PostListDto(
        int Id,
        string Slug,
        string Description,
        string ImageThumbnailUrl,
        UserDto Author,
        int LikesCount,
        int CommentsCount
    );

}
