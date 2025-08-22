using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Plenumio.Core.Entities;

namespace Plenumio.Infrastructure.Data.Configuration {
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser> {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder) {
            builder.HasData();
        }
    }
}