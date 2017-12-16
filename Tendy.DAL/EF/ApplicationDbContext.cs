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
        public DbSet<IdeaImage> IdeaImages { get; set; }
        public DbSet<AttachmentGroup> AttachmentGroups { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<PublicationImage> PublicationImages { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<PeopleGroup> PeopleGroups { get; set; }
    }
}
