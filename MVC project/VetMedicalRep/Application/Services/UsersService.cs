using Application.DTOs.UserDTO;
using Application.Interfaces;

namespace Application.Services
{
    public class UsersService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserResponse> AddUserAsync(UserAddRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var user = request.ToUser();
            var savedUser = await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return savedUser.ToUserResponse();
        }
    }
}
