using Microsoft.AspNetCore.Mvc;
using Presentation.Data;
using Presentation.Models;

namespace Presentation.Controllers;

public class ChatController : Controller
{
    private readonly AppDbContext _context;

    public ChatController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var messages = _context.ChatMessages
            .OrderByDescending(x => x.Id)
            .ToList();

        return View(messages);
    }

    [HttpPost]
    public IActionResult Send(string message)
    {
        if (string.IsNullOrWhiteSpace(message))
            return BadRequest();

        var botResponse = "You said: " + message;

        var chat = new ChatMessage
        {
            UserMessage = message,
            BotResponse = botResponse
        };

        _context.ChatMessages.Add(chat);
        _context.SaveChanges();

        return Json(new
        {
            userMessage = chat.UserMessage,
            botResponse = chat.BotResponse
        });
    }
}