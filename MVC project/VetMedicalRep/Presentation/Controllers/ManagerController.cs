using Application.DTOs.ManagerDTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Authorize]
    public class ManagerController : Controller
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddManager()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddManager(ManagerAddRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            await _managerService.AddManagerAsync(request);
            return RedirectToAction(nameof(Index));
        }
    }
}
