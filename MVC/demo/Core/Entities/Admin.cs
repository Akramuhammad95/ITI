using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Admin : IdentityUser
    {
        string Name { get; set; }
        string Email { get; set; }


    }
}
