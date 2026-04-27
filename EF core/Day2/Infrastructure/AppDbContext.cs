using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Instructor> Instructors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Load all configurations automatically
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}