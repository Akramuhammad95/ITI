using AIStudio.Models.ViewModels;

namespace AIStudio.Business.Models;

public record ChatResult(bool Success, string? Error, ChatMessageItemViewModel? Message, int UsedToday, int DailyLimit);
