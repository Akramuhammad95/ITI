using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer.DTOs;

namespace ApplicationLayer.Validation
{
    public class UserValidator
    {
        public void Validate(UserDto user)
        {
            if (string.IsNullOrWhiteSpace(user.Name))
                throw new Exception("Name is required");

            if (string.IsNullOrWhiteSpace(user.Email) || !user.Email.Contains("@"))
                throw new Exception("Invalid Email");

            if (user.Password.Length < 6)
                throw new Exception("Password must be at least 6 characters");
        }
    }
}
