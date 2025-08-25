using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Plenumio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Infrastructure.Data.Configuration {
    public class ApplicationUserTagConfiguration : IEntityTypeConfiguration<ApplicationUserTag> {
        public void Configure(EntityTypeBuilder<ApplicationUserTag> builder) {
            builder.HasKey(ut => new { ut.ApplicationUserId, ut.TagId });

            builder.HasOne(ut => ut.ApplicationUser)
                .WithMany(u => u.UserTags)
                .HasForeignKey(ut => ut.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ut => ut.Tag)
                .WithMany(t => t.UserTags)
                .HasForeignKey(ut => ut.TagId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
