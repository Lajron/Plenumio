using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Plenumio.Core.Entities;
using Plenumio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Infrastructure.Data.Configuration {
    public class PostConfiguration : IEntityTypeConfiguration<Post> {
        public void Configure(EntityTypeBuilder<Post> builder) {
            builder.HasData(
                new Post {
                    Id = 1,
                    Description = "Ovo je moj prvi post na Plenumio-u! Veoma sam uzbuđen što sam ovde.",
                    Slug = "prvi-post-na-plenumio",
                    PrivacyType = PrivacyType.Public,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow,
                    IsDeleted = false,
                }
            );
        }
    }
}
