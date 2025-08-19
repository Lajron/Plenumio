using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Plenumio.Core.Entities;

namespace Plenumio.Infrastructure.Data.Configuration {
    public class TagConfiguration : IEntityTypeConfiguration<Tag> {
        public void Configure(EntityTypeBuilder<Tag> builder) {
            builder.HasData(
                new Tag {
                    Id = 1,
                    Name = "technology",
                    DisplayedName = "Technology",
                    IsCanonical = true,
                    ParentId = null,
                    createdAt = DateTime.UtcNow
                },
                new Tag {
                    Id = 2,
                    Name = "life",
                    DisplayedName = "Life",
                    IsCanonical = true,
                    ParentId = null,
                    createdAt = DateTime.UtcNow
                },
                new Tag {
                    Id = 3,
                    Name = "science",
                    DisplayedName = "Science",
                    IsCanonical = true,
                    ParentId = null,
                    createdAt = DateTime.UtcNow
                },
                new Tag {
                    Id = 4,
                    Name = "art",
                    DisplayedName = "Art",
                    IsCanonical = true,
                    ParentId = null,
                    createdAt = DateTime.UtcNow
                },
                new Tag {
                    Id = 5,
                    Name = "gaming",
                    DisplayedName = "Gaming",
                    IsCanonical = true,
                    ParentId = null,
                    createdAt = DateTime.UtcNow
                }
            );
        }
    }
}
