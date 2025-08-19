using Microsoft.EntityFrameworkCore;
using Plenumio.Core.Entities;
using Plenumio.Infrastructure.Data.Configuration;
namespace Plenumio.Infrastructure.Data {
    public class PlenumioDbContext(DbContextOptions<PlenumioDbContext> options) : DbContext(options) {
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tag>()
                .HasOne(t => t.Parent)
                .WithMany(t => t.Children)
                .HasForeignKey(t => t.ParentId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.ApplyConfiguration(new TagConfiguration());

        }
    }
}
