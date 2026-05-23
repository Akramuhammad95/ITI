using Domain.Entities;
using System;


namespace Application.DTOs.ClientDTO
{
    public class ClientAddRequest
    {
        public string Name { get;  set; }
        public string Address { get;  set; }

        public Client ToClient(ClientAddRequest request)
        {
            return new Client( request.Name, request.Address);
          
        }
    

   
    }
}