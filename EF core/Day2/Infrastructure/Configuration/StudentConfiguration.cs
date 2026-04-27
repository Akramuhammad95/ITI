using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.StudentName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.StudentAge)
                   .IsRequired();

            // العلاقة: Student → StudentCourses
            builder.HasMany(s => s.StudentCourses)
                   .WithOne(sc => sc.Student)
                   .HasForeignKey(sc => sc.StudentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}