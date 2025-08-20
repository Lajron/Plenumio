using Microsoft.EntityFrameworkCore;
using Plenumio.Core.Entities;
using Plenumio.Infrastructure.Data.Configuration;
namespace Plenumio.Infrastructure.Data {
    public class PlenumioDbContext(DbContextOptions<PlenumioDbContext> options) : DbContext(options) {
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTag> PostTag { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new PostTagConfiguration());
        }
    }
}
