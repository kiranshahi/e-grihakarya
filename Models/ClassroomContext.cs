using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace egrihakarya
{
    public partial class ClassroomContext : DbContext
    {
        public ClassroomContext()
        {
        }

        public ClassroomContext(DbContextOptions<ClassroomContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assignments> Assignments { get; set; }
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<UserAssignments> UserAssignments { get; set; }
        public virtual DbSet<UserClasses> UserClasses { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        [NotMapped]
        public DbSet<ClassView> ClassViews { get; set; }
        [NotMapped]
        public DbSet<CommentView> CommentViews { get; set; }
        [NotMapped]
        public DbSet<JoinClass> JoinClasses { get; set; }
        [NotMapped]
        public DbSet<UserAssignment> UsersAssignments { get; set; }
        [NotMapped]
        public DbSet<UserAssignmentAdmin> UserAssignmentAdmins { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
