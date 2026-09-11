using DomainLayer.Entities;
namespace ApplicationLayer.Interfaces
{
    public interface IUserService
    {
        void Add(User user);
        List<User> GetAll();
    }

}
