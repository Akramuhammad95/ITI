using Application.DTOs.ClientDTO;
using Application.Services;
using Domain.Entities;

namespace VetMedicalRepTests
{
    public class ClientTests
    {
        private readonly ClientsService _clientsService;
        public ClientTests()
        {
            //_clientsService = new ClientsService();
            
        }
        [Fact]
        public async Task AddClient_NullClient_ThrowsArgumentNullException()

        {
            // Arrange
            ClientAddRequest? request = null;

            // Act & Assert
             await Assert.ThrowsAsync<ArgumentNullException>(() => _clientsService.AddClientAsync(request!));

        }
    }
}
