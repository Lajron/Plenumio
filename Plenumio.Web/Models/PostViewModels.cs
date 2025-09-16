using Plenumio.Core.Enums;
using Plenumio.Web.Models.Comment;
using Plenumio.Web.Models.Profile;
using Plenumio.Web.Models.Tag;
using System.ComponentModel.DataAnnotations;

namespace Plenumio.Web.Models {
    public record PostHeaderViewModel {
        public Guid PostId { get; init; }
        public UserSummaryVM Author { get; init; } = new();
        public DateTimeOffset UpdatedAt { get; init; }
        public DateTimeOffset CreatedAt { get; init; }
        public string Slug { get; init; } = string.Empty;
    }

    public record PostContentViewModel {
        public string Title { get; init; } = string.Empty;
        public string Content { get; init; } = string.Empty;
    }

    public record PostStatisticsViewModel {
        public Guid PostId { get; init; }
        public int CommentCount { get; init; }
        public int ReactionCount { get; init; }
        public IEnumerable<ReactionViewModel> Reactions { get; init; } = [];
    }

    public record PostSummaryVM {
        public Guid PostId { get; init; }
        public string Slug { get; init; } = string.Empty;
        public string Title { get; init; } = string.Empty;
        public string Content { get; init; } = string.Empty;
        public IEnumerable<TagSummaryVM> Tags { get; init; } = [];
        public IEnumerable<ImageViewModel> Images { get; init; } = [];
        public PrivacyType Privacy { get; init; }

        public PostType Type { get; init; }

    }

    public record PostVM {
        public PostType Type { get; init; }
        public PrivacyType Privacy { get; init; }
        public PostHeaderViewModel Header { get; init; } = new();
        public PostContentViewModel Body { get; init; } = new();
        public PostStatisticsViewModel Statistics { get; init; } = new();
        public IEnumerable<TagSummaryVM> Tags { get; init; } = [];
        public IEnumerable<ImageViewModel> Images { get; init; } = [];
        public IEnumerable<CommentVM> Comments { get; init; } = [];

    }

    public record PostFeedViewModel {
        public PostType Type { get; init; }
        public PostHeaderViewModel Header { get; init; } = new();
        public PostContentViewModel Body { get; init; } = new();
        public PostStatisticsViewModel Statistics { get; init; } = new();
        public DateTimeOffset CreatedAt { get; init; }
        public DateTimeOffset UpdatedAt { get; init; }
        public List<TagSummaryVM> Tags { get; init; } = [];
        public List<ImageViewModel> Images { get; init; } = [];
    }

    public record CreatePostViewModel {
        [Required(ErrorMessage = "Content can't be empty")]
        public string Content { get; set; } = string.Empty;
        public PrivacyType Privacy { get; set; } = PrivacyType.Public;
        public string Tags { get; set; } = string.Empty;
    }

    public record CreateArticleViewModel {
        [Required(ErrorMessage = "Title can't be empty")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Content can't be empty")]
        public string Content { get; set; } = string.Empty;

        public PrivacyType Privacy { get; set; } = PrivacyType.Public;
        public List<string> Images { get; set; } = [];
        public List<string> Tags { get; set; } = [];
    }
}
