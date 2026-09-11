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

public class ChatService(ApplicationDbContext dbContext, HttpClient httpClient) : IChatService
{
    private const string ChatEndpoint = "https://api.fireworks.ai/inference/v1/chat/completions";
    private const string ChatModel = "accounts/fireworks/models/llama-v3p1-8b-instruct";

    public async Task<ChatViewModel> GetChatAsync(string userId)
    {
        var messages = await dbContext.ChatMessages
            .Where(x => x.UserId == userId)
            .OrderBy(x => x.CreatedAtUtc)
            .Select(x => new ChatMessageItemViewModel
            {
                Id = x.Id,
                UserMessage = x.UserMessage,
                AiResponse = x.AiResponse,
                CreatedAtUtc = x.CreatedAtUtc
            })
            .ToListAsync();

        return new ChatViewModel
        {
            Messages = messages,
            DailyLimit = AppLimits.ChatMessagesPerDay,
            UsedToday = await CountTodayAsync(userId)
        };
    }

    public async Task<ChatResult> SendMessageAsync(string userId, string message)
    {
        message = message.Trim();
        if (string.IsNullOrWhiteSpace(message))
        {
            return new ChatResult(false, "Message is required.", null, await CountTodayAsync(userId), AppLimits.ChatMessagesPerDay);
        }

        var usedToday = await CountTodayAsync(userId);
        if (usedToday >= AppLimits.ChatMessagesPerDay)
        {
            return new ChatResult(false, "Daily chat limit reached.", null, usedToday, AppLimits.ChatMessagesPerDay);
        }

        var apiKey = Environment.GetEnvironmentVariable("FIREWORKS_API_KEY");
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            return new ChatResult(false, "FIREWORKS_API_KEY is not configured.", null, usedToday, AppLimits.ChatMessagesPerDay);
        }

        var aiResponse = await AskFireworksAsync(apiKey, message);
        var entity = new ChatMessage
        {
            UserId = userId,
            UserMessage = message,
            AiResponse = aiResponse,
            CreatedAtUtc = DateTime.UtcNow
        };

        dbContext.ChatMessages.Add(entity);
        await dbContext.SaveChangesAsync();

        var item = new ChatMessageItemViewModel
        {
            Id = entity.Id,
            UserMessage = entity.UserMessage,
            AiResponse = entity.AiResponse,
            CreatedAtUtc = entity.CreatedAtUtc
        };

        return new ChatResult(true, null, item, usedToday + 1, AppLimits.ChatMessagesPerDay);
    }

    private async Task<int> CountTodayAsync(string userId)
    {
        var start = DateTime.UtcNow.Date;
        return await dbContext.ChatMessages.CountAsync(x => x.UserId == userId && x.CreatedAtUtc >= start);
    }

    private async Task<string> AskFireworksAsync(string apiKey, string message)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, ChatEndpoint);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        request.Content = JsonContent.Create(new
        {
            model = ChatModel,
            messages = new[]
            {
                new { role = "system", content = "You are a helpful assistant inside AIStudio." },
                new { role = "user", content = message }
            },
            temperature = 0.7,
            max_tokens = 1000
        });

        using var response = await httpClient.SendAsync(request);
        var body = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException($"Fireworks chat request failed: {(int)response.StatusCode} {body}");
        }

        var json = JsonNode.Parse(body);
        var content = json?["choices"]?[0]?["message"]?["content"]?.GetValue<string>();
        return string.IsNullOrWhiteSpace(content) ? "No response returned." : content;
    }
}
