using Application.DTOs.ManagerDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IManagerService
    {
        public Task<ManagerResponse> AddManagerAsync(ManagerAddRequest request);
    }
}