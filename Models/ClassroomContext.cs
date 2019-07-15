using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Assignments>(entity =>
            {
                entity.HasIndex(e => e.CasclassId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddedOn)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CasclassId).HasColumnName("CASClassId");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.DueDate)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Classes>(entity =>
            {
                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Room).HasMaxLength(100);

                entity.Property(e => e.Section).HasMaxLength(100);

                entity.Property(e => e.Subject).HasMaxLength(100);

                entity.Property(e => e.SubjectCode).HasMaxLength(50);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssignmentId).HasColumnName("AssignmentID");

                entity.Property(e => e.Comment1).HasColumnName("Comment");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<UserAssignments>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssignmentId).HasColumnName("AssignmentID");

                entity.Property(e => e.IsSubmitted).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubmittedOn).HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<UserClasses>(entity =>
            {
                entity.HasKey(e => e.UserClassId);

                entity.Property(e => e.UserClassId).HasColumnName("UserClassID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.FirstName).HasMaxLength(250);

                entity.Property(e => e.LastName).HasMaxLength(250);

                entity.Property(e => e.Password).HasMaxLength(250);

                entity.Property(e => e.Role).HasMaxLength(250);

                entity.Property(e => e.Token).HasMaxLength(250);

                entity.Property(e => e.Username).HasMaxLength(250);
            });
        }
    }
}
