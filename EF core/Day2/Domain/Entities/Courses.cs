using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }

        public virtual ICollection<StudentCourses> StudentCourses { get; set; } = new List<StudentCourses>();
    }
}
