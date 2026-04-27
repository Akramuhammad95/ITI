using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.ToTable("Instructors");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name)
                   .IsRequired()
                   .HasMaxLength(100);


            // Instructor → Courses
            builder.HasMany(i => i.Courses)
                   .WithOne(c => c.Instructor)
                   .HasForeignKey(c => c.InstructorId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}