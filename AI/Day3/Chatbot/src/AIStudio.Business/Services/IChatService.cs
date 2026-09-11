using AIStudio.Business.Models;
using AIStudio.Models.ViewModels;

namespace AIStudio.Business.Services;

public interface IChatService
{
    Task<ChatViewModel> GetChatAsync(string userId);
    Task<ChatResult> SendMessageAsync(string userId, string message);
}
