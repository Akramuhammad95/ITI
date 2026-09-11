using System;
using System.Collections.Generic;
using System.Text;

namespace Day2.Task2
{
    public class Phonebook
    {
        private Dictionary<string, string> _contacts { get; set; } = new Dictionary<string, string>();

        public string this[string name]
        {
            get
            {
                if (_contacts.ContainsKey(name))
                {
                    return $"{name} : {_contacts[name]}";
                }
                else
                {
                    return $"Contact {name} not found.";
                }
            }
            set
            {
                if (int.TryParse(value, out int number))
                {
                    _contacts[name] = "0"+number.ToString();
                }
                else
                {
                    throw new ArgumentException("Value must be a valid phone number.");
                }
                if (value.Length != 11)
                {
                    throw new ArgumentException("Phone number must be 11 digits long.");
                }
                if(!value.StartsWith("01"))
                {
                    throw new ArgumentException("Phone number must start with 01.");
                }
                if(name == null || name.Trim() == "" || name.Length <3 || name.Length > 50)
                {
                    throw new ArgumentException("Name must be valid.");
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var contact in _contacts)
            {
                sb.AppendLine($"{contact.Key} : {contact.Value}");
            }
            return sb.ToString();
        }

        public void SearchContact(string name)
        {
            if (_contacts.ContainsKey(name))
            {
                Console.WriteLine($"{name} : {_contacts[name]}");
            }
            else
            {
                throw new ArgumentException($"Contact {name} not found.");
            }
        }
        

     


    }
}
