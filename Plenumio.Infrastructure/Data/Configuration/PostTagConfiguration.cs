using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Plenumio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Infrastructure.Data.Configuration {
    public class PostTagConfiguration : IEntityTypeConfiguration<PostTag> {
        public void Configure(EntityTypeBuilder<PostTag> builder) {
            builder.HasKey(pt => new { pt.PostId, pt.TagId });

            builder.HasOne(pt => pt.Post)
                .WithMany(p => p.PostTag)
                .HasForeignKey(pt => pt.PostId);

            builder.HasOne(pt => pt.Tag)
                .WithMany(t => t.PostTag)
                .HasForeignKey(pt => pt.TagId);

            builder.HasData(
                new PostTag {
                    PostId = 1,
                    TagId = 1
                },
                new PostTag {
                    PostId = 1,
                    TagId = 2
                },
                new PostTag {
                    PostId = 1,
                    TagId = 3
                }
            );
        }
    }
}
