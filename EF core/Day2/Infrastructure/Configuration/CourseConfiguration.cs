using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title)
                   .IsRequired()
                   .HasMaxLength(150);

            // Course → Instructor (Many-to-One)
            builder.HasOne(c => c.Instructor)
                   .WithMany(i => i.Courses)
                   .HasForeignKey(c => c.InstructorId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Course → StudentCourses
            builder.HasMany(c => c.StudentCourses)
                   .WithOne(sc => sc.Course)
                   .HasForeignKey(sc => sc.CourseId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}