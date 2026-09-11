using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace Presentation.Services;

public class ImageService
{
    private readonly HttpClient _httpClient;

    public ImageService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GenerateAsync(string prompt)
    {
        var apiKey =
            Environment.GetEnvironmentVariable("FIREWORKS_API_KEY");

        var request = new
        {
            prompt = prompt,
            width = 1024,
            height = 1024
        };

        var json = JsonConvert.SerializeObject(request);

        var httpRequest = new HttpRequestMessage(
            HttpMethod.Post,
            "https://api.fireworks.ai/inference/v1/workflows/accounts/fireworks/models/flux-1-schnell-fp8/text_to_image");

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

        return result.images[0].url.ToString();
    }
}