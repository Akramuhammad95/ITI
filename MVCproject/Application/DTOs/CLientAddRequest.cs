using Domain.Entities;
using System;


namespace Application.DTOs
{
    public class CLientAddRequest
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
    

    public Client ToClient(CLientAddRequest request)
        {
            return new Client(Name, Address);

        }
    }
}