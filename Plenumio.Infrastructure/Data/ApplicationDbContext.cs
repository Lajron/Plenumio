using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Plenumio.Core.Entities;
using Plenumio.Infrastructure.Data.Configuration;

namespace Plenumio.Infrastructure.Data {
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : IdentityDbContext<ApplicationUser>(options) {
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTag> PostTag { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TagConfiguration());

            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new PostTagConfiguration());

            //modelBuilder.ApplyConfiguration(new ImageConfiguration());
            //modelBuilder.ApplyConfiguration(new PostImageConfiguration());

            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            //modelBuilder.ApplyConfiguration(new FollowConfigurations());
            //modelBuilder.ApplyConfiguration(new ApplicationUserTagConfiguration());

            //modelBuilder.ApplyConfiguration(new ApplicationUserPostConfiguration());
            //modelBuilder.ApplyConfiguration(new CommentConfiguration());
            //modelBuilder.ApplyConfiguration(new ReactionConfiguration());


        }
    }
}
