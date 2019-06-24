using Microsoft.EntityFrameworkCore;

namespace CAS
{
    public class CASContext : DbContext
    {
        public CASContext(DbContextOptions<CASContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<CASClass> Classes { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Comments> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserClass>()
                .HasKey(uc => new { uc.ClassID, uc.UserID });
            modelBuilder.Entity<UserClass>()
                .HasOne(u => u.User)
                .WithMany(uc => uc.UserClass)
                .HasForeignKey(u => u.UserID);
            modelBuilder.Entity<UserClass>()
                .HasOne(c => c.Class)
                .WithMany(uc => uc.UserClass)
                .HasForeignKey(c => c.ClassID);
        }
    }
}
