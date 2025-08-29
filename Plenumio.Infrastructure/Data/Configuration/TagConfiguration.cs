using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Plenumio.Core.Entities;
using Plenumio.Core.Enums;
using System.Reflection.Emit;

namespace Plenumio.Infrastructure.Data.Configuration {
    public class TagConfiguration : IEntityTypeConfiguration<Tag> {
        public void Configure(EntityTypeBuilder<Tag> builder) {
            builder.Property(t => t.Type)
                .HasConversion<string>();

            builder.HasOne(t => t.Parent)
                .WithMany(t => t.Children)
                .HasForeignKey(t => t.ParentId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Tag {
                    Id = Guid.NewGuid(),
                    Name = "technology",
                    DisplayedName = "Technology",
                    Type = TagType.Default,
                    ParentId = null,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow,
                    IsDeleted = false
                },
                new Tag {
                    Id = Guid.NewGuid(),
                    Name = "life",
                    DisplayedName = "Life",
                    Type = TagType.Default,
                    ParentId = null,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow,
                    IsDeleted = false
                },
                new Tag {
                    Id = Guid.NewGuid(),
                    Name = "science",
                    DisplayedName = "Science", 
                    Type = TagType.Default,
                    ParentId = null,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow,
                    IsDeleted = false
                },
                new Tag {
                    Id = Guid.NewGuid(),
                    Name = "art",
                    DisplayedName = "Art",
                    Type = TagType.Default,
                    ParentId = null,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow,
                    IsDeleted = false
                },
                new Tag {
                    Id = Guid.NewGuid(),
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
