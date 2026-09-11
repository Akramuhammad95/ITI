using System.ComponentModel.DataAnnotations;

namespace Dplomty.PL.ViewModel.Student
{
    public class CreateStudentVM
    {
        [Required]
        public string Name { get; set; }
        [Range(15, 80)]
        public int Age { get; set; }
    }
}
