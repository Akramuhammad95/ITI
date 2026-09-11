using AIStudio.Models.ViewModels;

namespace AIStudio.Business.Models;

public record ImageResult(bool Success, string? Error, GeneratedImageItemViewModel? Image, int UsedToday, int DailyLimit);
