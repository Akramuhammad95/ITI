using ApplicationLayer.DTOs;
using ApplicationLayer.Interfaces;
using ApplicationLayer.Services;
using ApplicationLayer.Validation;
using DomainLayer.Entities;

namespace InfrastructureLayer
{
  
        public class UserRepository : IUserService
        {
            private List<User> users = new List<User>();

            public void Add(User user)
            {
                users.Add(user);
            }

            public List<User> GetAll()
            {
                return users;
            }
        }

   
}