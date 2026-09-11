using AIStudio.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AIStudio.Models;

namespace AIStudio.Web.Controllers;

[Authorize]
public class ChatController(IChatService chatService, UserManager<ApplicationUser> userManager) : Controller
{
    public async Task<IActionResult> Index()
    {
        var userId = userManager.GetUserId(User)!;
        var model = await chatService.GetChatAsync(userId);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Send(string message)
    {
        try
        {
            var userId = userManager.GetUserId(User)!;
            var result = await chatService.SendMessageAsync(userId, message ?? string.Empty);
            return Json(result);
        }
        catch (Exception ex)
        {
            return Json(new { success = false, error = ex.Message });
        }
    }
}
