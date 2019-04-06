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
        public DbSet<ClassView> ClassesView { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<UserClass> UserClasses { get; set; }
        public DbSet<UserAssignment> UserAssignments { get; set; }
    }
}
