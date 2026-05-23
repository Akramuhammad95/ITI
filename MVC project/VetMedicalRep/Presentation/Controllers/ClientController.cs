using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetClients()
        {

            return View();
        }


        public IActionResult AddClient()
        {
           
            return View();
        }
    }
}