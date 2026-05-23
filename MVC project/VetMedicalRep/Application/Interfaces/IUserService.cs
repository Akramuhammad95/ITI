using Application.DTOs.UserDTO;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse> AddUserAsync(UserAddRequest request);
    }
}
