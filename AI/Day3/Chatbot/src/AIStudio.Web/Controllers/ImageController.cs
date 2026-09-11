using AIStudio.Business.Services;
using AIStudio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AIStudio.Web.Controllers;

[Authorize]
public class ImageController(IImageService imageService, UserManager<ApplicationUser> userManager) : Controller
{
    public async Task<IActionResult> Index()
    {
        var userId = userManager.GetUserId(User)!;
        var model = await imageService.GetImagesAsync(userId);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Generate(string prompt)
    {
        try
        {
            var userId = userManager.GetUserId(User)!;
            var result = await imageService.GenerateImageAsync(userId, prompt ?? string.Empty);
            return Json(result);
        }
        catch (Exception ex)
        {
            return Json(new { success = false, error = ex.Message });
        }
    }
}
