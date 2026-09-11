using AIStudio.Business.Models;
using AIStudio.Models.ViewModels;

namespace AIStudio.Business.Services;

public interface IImageService
{
    Task<ImageGeneratorViewModel> GetImagesAsync(string userId);
    Task<ImageResult> GenerateImageAsync(string userId, string prompt);
}
