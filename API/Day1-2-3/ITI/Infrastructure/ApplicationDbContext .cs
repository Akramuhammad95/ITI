using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =========================
            // Department → Student (1 : Many)
            // =========================
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Students)
                .HasForeignKey(s => s.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // =========================
            // Department → Supervisor (Many Departments → 1 Supervisor)
            // =========================
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Supervisor)
                .WithMany(s => s.Departments)
                .HasForeignKey(d => d.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);

            // =========================
            // Student ↔ Course (Many to Many)
            // =========================
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithMany(c => c.Students)
                .UsingEntity(j => j.ToTable("StudentCourses"));
        }
    }
}