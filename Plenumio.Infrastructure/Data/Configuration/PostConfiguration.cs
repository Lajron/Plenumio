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
            builder.HasData();
        }
    }
}
