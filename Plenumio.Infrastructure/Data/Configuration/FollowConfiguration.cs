using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Plenumio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Infrastructure.Data.Configuration {
    public class FollowConfiguration : IEntityTypeConfiguration<Follow> {
        public void Configure(EntityTypeBuilder<Follow> builder) {
            builder.HasIndex(f => new { f.FollowerId, f.FollowingId })
                .IsUnique();

            builder.Property(f => f.Status)
                .HasConversion<string>();

            builder.HasOne(f => f.Follower)
                .WithMany(u => u.Following)
                .HasForeignKey(f => f.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.Following)
                    .WithMany(u => u.Followers) 
                    .HasForeignKey(f => f.FollowingId)
                    .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
