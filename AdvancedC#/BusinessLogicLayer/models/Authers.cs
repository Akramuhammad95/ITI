using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.models
{
    public class Authers
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private string _phone;

        public string Phone
        {
            get { return _phone; }
            set
            {
                if (value.Length != 11)
                    throw new Exception("Phone number must be 11 digits long.");

                foreach (char c in value)
                {
                    if (!char.IsDigit(c))
                        throw new Exception("Phone number must contain only digits.");
                }

                _phone = value;
            }
        }

        public string Email { get; set; }
        public string Address { get; set; }
    }
}