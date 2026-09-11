using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        //list of employees in the department
        public ICollection<Employee> Employees{ get; set; } = new List<Employee>();
    }
}
