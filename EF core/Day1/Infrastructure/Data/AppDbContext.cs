using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Dependent> Dependents { get; set; }
        public DbSet<WorksFor> WorksFors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =========================
            // Employee
            // =========================
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee", "dbo");

                entity.HasKey(e => e.Ssn);

                entity.Property(e => e.Fname).HasMaxLength(50);
                entity.Property(e => e.Lname).HasMaxLength(50);
                entity.Property(e => e.Address).HasMaxLength(100);
                entity.Property(e => e.Sex).HasMaxLength(10);

                // Employee -> Department (Many-to-One)
                entity.HasOne(e => e.DnoNavigation)
                    .WithMany(d => d.Employees)
                    .HasForeignKey(e => e.Dno)
                    .OnDelete(DeleteBehavior.SetNull);

                // Self relationship (Supervisor)
                entity.HasOne(e => e.SuperssnNavigation)
                    .WithMany(e => e.InverseSuperssnNavigation)
                    .HasForeignKey(e => e.Superssn)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // =========================
            // Department
            // =========================
            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Departments", "dbo");

                entity.HasKey(d => d.Dnum);

                entity.Property(d => d.Dname).HasMaxLength(50);

                // Department Manager (Employee)
                entity.HasOne(d => d.MgrssnNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Mgrssn)
                    .OnDelete(DeleteBehavior.NoAction);

                // Department -> Employees (1-M)
                entity.HasMany(d => d.Employees)
                    .WithOne(e => e.DnoNavigation)
                    .HasForeignKey(e => e.Dno);
            });

            // =========================
            // Project
            // =========================
            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project", "dbo");

                entity.HasKey(p => p.Pnumber);

                entity.Property(p => p.Pname).HasMaxLength(50);
                entity.Property(p => p.Plocation).HasMaxLength(50);
                entity.Property(p => p.City).HasMaxLength(50);

                entity.HasOne(p => p.DnumNavigation)
                    .WithMany(d => d.Projects)
                    .HasForeignKey(p => p.Dnum);
            });

            // =========================
            // Dependent
            // =========================
            modelBuilder.Entity<Dependent>(entity =>
            {
                entity.ToTable("Dependent", "dbo");

                entity.HasKey(d => new { d.Essn, d.DependentName });

                entity.Property(d => d.DependentName).HasMaxLength(50);
                entity.Property(d => d.Sex).HasMaxLength(10);

                entity.HasOne(d => d.EssnNavigation)
                    .WithMany(e => e.Dependents)
                    .HasForeignKey(d => d.Essn)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // =========================
            // Works_for (Junction Table)
            // =========================
            modelBuilder.Entity<WorksFor>(entity =>
            {
                entity.ToTable("Works_for", "dbo");

                entity.HasKey(w => new { w.Essn, w.Pno });

                entity.HasOne(w => w.EssnNavigation)
                    .WithMany(e => e.WorksFors)
                    .HasForeignKey(w => w.Essn)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(w => w.PnoNavigation)
                    .WithMany(p => p.WorksFors)
                    .HasForeignKey(w => w.Pno)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

    }
}