using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Employee : IdentityUser
    {
        public string Name { get; set; }

        public string Email { get; set; }


        [ForeignKey("Department")]

        public string DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
