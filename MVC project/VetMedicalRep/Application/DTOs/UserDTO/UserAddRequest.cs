using Domain.Entities;

namespace Application.DTOs.UserDTO
{
    public class UserAddRequest
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public User ToUser()
        {
            return new User(FullName, Email, PasswordHash);
        }
    }
}
