using Application.DTOs.InventoryDTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Authorize]
    public class InventoryController : Controller
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddInventory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddInventory(InventoryAddRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            await _inventoryService.AddInventoryAsync(request);
            return RedirectToAction(nameof(Index));
        }
    }
}
