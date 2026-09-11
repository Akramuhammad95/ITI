using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Nodes;
using AIStudio.Business.Constants;
using AIStudio.Business.Models;
using AIStudio.Data;
using AIStudio.Models;
using AIStudio.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AIStudio.Business.Services;

public class ImageService(ApplicationDbContext dbContext, HttpClient httpClient) : IImageService
{
    private const string ImageEndpoint = "https://api.fireworks.ai/inference/v1/workflows/accounts/fireworks/models/flux-1-schnell-fp8/text_to_image";

    public async Task<ImageGeneratorViewModel> GetImagesAsync(string userId)
    {
        var images = await dbContext.GeneratedImages
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.CreatedAtUtc)
            .Select(x => new GeneratedImageItemViewModel
            {
                Id = x.Id,
                Prompt = x.Prompt,
                ImageUrl = x.ImageUrl,
                CreatedAtUtc = x.CreatedAtUtc
            })
            .ToListAsync();

        return new ImageGeneratorViewModel
        {
            Images = images,
            DailyLimit = AppLimits.ImagesPerDay,
            UsedToday = await CountTodayAsync(userId)
        };
    }

    public async Task<ImageResult> GenerateImageAsync(string userId, string prompt)
    {
        prompt = prompt.Trim();
        if (string.IsNullOrWhiteSpace(prompt))
        {
            return new ImageResult(false, "Prompt is required.", null, await CountTodayAsync(userId), AppLimits.ImagesPerDay);
        }

        var usedToday = await CountTodayAsync(userId);
        if (usedToday >= AppLimits.ImagesPerDay)
        {
            return new ImageResult(false, "Daily image limit reached.", null, usedToday, AppLimits.ImagesPerDay);
        }

        var apiKey = Environment.GetEnvironmentVariable("FIREWORKS_API_KEY");
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            return new ImageResult(false, "FIREWORKS_API_KEY is not configured.", null, usedToday, AppLimits.ImagesPerDay);
        }

        var imageUrl = await GenerateWithFireworksAsync(apiKey, prompt);
        var entity = new GeneratedImage
        {
            UserId = userId,
            Prompt = prompt,
            ImageUrl = imageUrl,
            CreatedAtUtc = DateTime.UtcNow
        };

        dbContext.GeneratedImages.Add(entity);
        await dbContext.SaveChangesAsync();

        var item = new GeneratedImageItemViewModel
        {
            Id = entity.Id,
            Prompt = entity.Prompt,
            ImageUrl = entity.ImageUrl,
            CreatedAtUtc = entity.CreatedAtUtc
        };

        return new ImageResult(true, null, item, usedToday + 1, AppLimits.ImagesPerDay);
    }

    private async Task<int> CountTodayAsync(string userId)
    {
        var start = DateTime.UtcNow.Date;
        return await dbContext.GeneratedImages.CountAsync(x => x.UserId == userId && x.CreatedAtUtc >= start);
    }

    private async Task<string> GenerateWithFireworksAsync(string apiKey, string prompt)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, ImageEndpoint);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        request.Content = JsonContent.Create(new
        {
            prompt,
            aspect_ratio = "1:1"
        });

        using var response = await httpClient.SendAsync(request);
        var body = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException($"Fireworks image request failed: {(int)response.StatusCode} {body}");
        }

        var json = JsonNode.Parse(body);
        var directUrl = json?["data"]?[0]?["url"]?.GetValue<string>()
            ?? json?["images"]?[0]?["url"]?.GetValue<string>()
            ?? json?["image_url"]?.GetValue<string>();

        if (!string.IsNullOrWhiteSpace(directUrl))
        {
            return directUrl;
        }

        var base64 = json?["data"]?[0]?["b64_json"]?.GetValue<string>()
            ?? json?["images"]?[0]?["b64_json"]?.GetValue<string>()
            ?? json?["image"]?.GetValue<string>();

        if (string.IsNullOrWhiteSpace(base64))
        {
            throw new InvalidOperationException("Fireworks image response did not include an image.");
        }

        return base64.StartsWith("data:", StringComparison.OrdinalIgnoreCase)
            ? base64
            : $"data:image/png;base64,{base64}";
    }
}
