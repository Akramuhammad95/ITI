using Application.DTOs.AreaDTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Authorize]
    public class AreaController : Controller
    {
        private readonly IAreaService _areaService;

        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddArea()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddArea(AreaAddRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            await _areaService.AddAreaAsync(request);
            return RedirectToAction(nameof(Index));
        }
    }
}
