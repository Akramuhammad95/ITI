using Application.DTOs.AreaDTO;
using Application.DTOs.ClientDTO;
using Application.DTOs.InventoryDTO;
using Application.DTOs.ProductDTO;
using Application.DTOs.VisitDTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;

namespace Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IAreaService _areaService;
        private readonly IClientService _clientService;
        private readonly IInventoryService _inventoryService;
        private readonly IProductService _productService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVisitService _visitService;

        public HomeController(
            IAreaService areaService,
            IClientService clientService,
            IInventoryService inventoryService,
            IProductService productService,
            IUnitOfWork unitOfWork,
            IVisitService visitService)
        {
            _areaService = areaService;
            _clientService = clientService;
            _inventoryService = inventoryService;
            _productService = productService;
            _unitOfWork = unitOfWork;
            _visitService = visitService;
        }

        [HttpGet("dashboard")]
        public async Task<ActionResult<DashboardViewModel>> Index()
        {
            var model = await BuildDashboardAsync();
            return Ok(model);
        }

        [HttpPost("clients")]
        public async Task<IActionResult> AddClient([FromBody] ClientAddRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _clientService.AddClientAsync(request);
            return Ok();
        }

        [HttpPost("visits")]
        public async Task<IActionResult> AddVisit([FromBody] VisitAddRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _visitService.AddVisitAsync(request);
            return Ok();
        }

        [HttpPost("areas")]
        public async Task<IActionResult> AddArea([FromBody] AreaAddRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _areaService.AddAreaAsync(request);
            return Ok();
        }

        [HttpPost("products")]
        public async Task<IActionResult> AddProduct([FromBody] ProductAddRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _productService.AddProductAsync(request);
            return Ok();
        }

        [HttpPost("inventories")]
        public async Task<IActionResult> AddInventory([FromBody] InventoryAddRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _inventoryService.AddInventoryAsync(request);
            return Ok();
        }

        private async Task<DashboardViewModel> BuildDashboardAsync()
        {
            var clients = await _unitOfWork.ClientRepository.GetAllAsync();
            var visits = await _unitOfWork.VisitRepository.GetAllAsync();
            var areas = await _unitOfWork.AreaRepository.GetAllAsync();
            var products = await _unitOfWork.ProductRepository.GetAllAsync();
            var inventories = await _unitOfWork.InventoryRepository.GetAllAsync();

            return new DashboardViewModel
            {
                Clients = clients.Select(client => client.ToClientResponse()).ToList(),
                Visits = visits.Select(visit => visit.ToVisitResponse()).ToList(),
                Areas = areas.Select(area => area.ToAreaResponse()).ToList(),
                Products = products.Select(product => product.ToProductResponse()).ToList(),
                Inventories = inventories.Select(inventory => inventory.ToInventoryResponse()).ToList()
            };
        }
    }
}
