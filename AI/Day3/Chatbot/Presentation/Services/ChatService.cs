using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
namespace Presentation.Services;

public class ChatService
{
    private readonly HttpClient _httpClient;

    public ChatService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> AskAsync(string message)
    {
        var apiKey =
            Environment.GetEnvironmentVariable("FIREWORKS_API_KEY");

        var request = new
        {
            model = "accounts/fireworks/models/llama-v3p1-8b-instruct",
            messages = new[]
            {
                new
                {
                    role = "user",
                    content = message
                }
            }
        };

        var json = JsonConvert.SerializeObject(request); //post  as json async

        var httpRequest = new HttpRequestMessage(
            HttpMethod.Post,
            "https://api.fireworks.ai/inference/v1/chat/completions");

        httpRequest.Headers.Authorization =
            new AuthenticationHeaderValue("Bearer", apiKey);

        httpRequest.Content = new StringContent(
            json,
            Encoding.UTF8,
            "application/json");

        var response = await _httpClient.SendAsync(httpRequest);

        response.EnsureSuccessStatusCode();

        var body = await response.Content.ReadAsStringAsync();

        dynamic result = JsonConvert.DeserializeObject(body)!;

        return result.choices[0].message.content.ToString();
    }
}