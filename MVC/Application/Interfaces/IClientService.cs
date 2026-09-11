using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IClientService
    {
        public Task<ClientResponse> AddClient(CLientAddRequest request);
     
    }
}
