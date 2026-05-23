using Domain.Entities;
using System;

namespace Application.DTOs.ManagerDTO
{
    public class ManagerAddRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public Manager ToManager(ManagerAddRequest request)
        {
            return new Manager(request.Name, request.Email);
        }
    }
}