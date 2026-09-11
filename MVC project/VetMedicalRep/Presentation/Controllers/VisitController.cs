using Application.DTOs.VisitDTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class VisitController : ControllerBase
    {
        private readonly IVisitService _visitService;

        public VisitController(IVisitService visitService)
        {
            _visitService = visitService;
        }

        [HttpPost]
        public async Task<IActionResult> AddVisit([FromBody] VisitAddRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _visitService.AddVisitAsync(request);
            return Ok();
        }
    }
}
