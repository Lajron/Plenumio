using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Plenumio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Infrastructure.Data.Configuration {
    public class ReactionConfiguration : IEntityTypeConfiguration<Reaction> {
        public void Configure(EntityTypeBuilder<Reaction> builder) {
            builder.Property(r => r.Type)
                .HasConversion<string>();

            builder.HasOne(r => r.Post)
                .WithMany(p => p.Reactions)
                .HasForeignKey(r => r.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.ApplicationUser)
                .WithMany(u => u.Reactions)
                .HasForeignKey(r => r.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
