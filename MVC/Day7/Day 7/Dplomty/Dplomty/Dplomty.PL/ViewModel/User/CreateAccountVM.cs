using System.ComponentModel.DataAnnotations;

namespace Dplomty.PL.ViewModel.User
{
    public class CreateAccountVM
    {
        [Required]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
