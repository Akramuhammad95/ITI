using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using System.Runtime.CompilerServices;
using Xunit;

namespace VetMedicalRepTests
{
    public class ClientServiceTests
    {
        private readonly IClientService _clientService;
        

        public ClientServiceTests()
        {
            _clientService = new ClientsService();
        }

        [Fact]
        public async  Task AddClient_NullClient()
        {
            //arrange
            CLientAddRequest? request = null;

           
            //Assert
            Assert.Throws<ArgumentNullException>(() => 
            
            //Act
            await _clientService.AddClient(request)
            
            );
            

        }
    }
}
