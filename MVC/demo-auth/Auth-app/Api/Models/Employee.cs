using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class Employee : IdentityUser
    {
        public string Name { get; set; }
        public string Position { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; } = new Department();

    }
}
