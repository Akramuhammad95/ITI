using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class StudentCoursesConfiguration : IEntityTypeConfiguration<StudentCourses>
    {
        public void Configure(EntityTypeBuilder<StudentCourses> builder)
        {
            builder.ToTable("StudentCourses");

            // Composite Key
            builder.HasKey(sc => new { sc.StudentId, sc.CourseId });

            // Student relation
            builder.HasOne(sc => sc.Student)
                   .WithMany(s => s.StudentCourses)
                   .HasForeignKey(sc => sc.StudentId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Course relation
            builder.HasOne(sc => sc.Course)
                   .WithMany(c => c.StudentCourses)
                   .HasForeignKey(sc => sc.CourseId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}