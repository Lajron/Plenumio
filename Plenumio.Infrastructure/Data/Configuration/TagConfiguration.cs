using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Plenumio.Core.Entities;
using Plenumio.Core.Enums;
using System.Reflection.Emit;

namespace Plenumio.Infrastructure.Data.Configuration {
    public class TagConfiguration : IEntityTypeConfiguration<Tag> {
        public void Configure(EntityTypeBuilder<Tag> builder) {
            builder.HasOne(t => t.Parent)
                .WithMany(t => t.Children)
                .HasForeignKey(t => t.ParentId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Tag {
                    Id = 1,
                    Name = "technology",
                    DisplayedName = "Technology",
                    Type = TagType.Default,
                    ParentId = null,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow,
                    IsDeleted = false
                },
                new Tag {
                    Id = 2,
                    Name = "life",
                    DisplayedName = "Life",
                    Type = TagType.Default,
                    ParentId = null,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow,
                    IsDeleted = false
                },
                new Tag {
                    Id = 3,
                    Name = "science",
                    DisplayedName = "Science", 
                    Type = TagType.Default,
                    ParentId = null,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow,
                    IsDeleted = false
                },
                new Tag {
                    Id = 4,
                    Name = "art",
                    DisplayedName = "Art",
                    Type = TagType.Default,
                    ParentId = null,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow,
                    IsDeleted = false
                },
                new Tag {
                    Id = 5,
                    Name = "gaming",
                    DisplayedName = "Gaming",
                    Type = TagType.Default,
                    ParentId = null,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow,
                    IsDeleted = false
                }
            );
        }
    }
}
