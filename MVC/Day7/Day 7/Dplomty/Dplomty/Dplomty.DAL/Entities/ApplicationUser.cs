using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dplomty.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? Address { get; set; }
     
    }
}
