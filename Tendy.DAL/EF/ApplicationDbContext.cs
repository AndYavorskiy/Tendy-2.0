using Tendy.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Tendy.DAL.EF
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {   }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Link>().Property(p => p.IsPrivate).HasDefaultValue(false);
			modelBuilder.Entity<File>().Property(p => p.IsPrivate).HasDefaultValue(false);
			modelBuilder.Entity<Request>().Property(p => p.IsAccepted).HasDefaultValue(false);
			modelBuilder.Entity<Request>().Property(p => p.IsActive).HasDefaultValue(true);

			modelBuilder.Entity<IdeaCategory>()
				.HasKey(t => new { t.IdeaId, t.CategoryId });

            modelBuilder.Entity<IdeaCategory>()
                .HasOne(pt => pt.Idea)
                .WithMany(p => p.IdeaCategories)
                .HasForeignKey(pt => pt.IdeaId);

            modelBuilder.Entity<IdeaCategory>()
                .HasOne(pt => pt.Category)
                .WithMany(t => t.IdeaCategories)
                .HasForeignKey(pt => pt.CategoryId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Idea> Ideas { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<File> Files { get; set; }
		public DbSet<Category> Categories { get; set; }
        public DbSet<Request> Requests { get; set; }
    }
}
