using Application.DTOs.VisitDTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Authorize]
    public class VisitController : Controller
    {
        private readonly IVisitService _visitService;

        public VisitController(IVisitService visitService)
        {
            _visitService = visitService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddVisit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddVisit(VisitAddRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            await _visitService.AddVisitAsync(request);
            return RedirectToAction(nameof(Index));
        }
    }
}
