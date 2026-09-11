using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Customer_service_fine_tuning.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public HomeController(
            HttpClient httpClient,
            IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendQuestion(string question)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(question))
                {
                    ViewBag.Answer = "Please enter a question.";
                    return View("Index");
                }

                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(
                        "Bearer",
                        _config["APIkey"]);

                var requestBody = new
                {
                    model = _config["model"],
                    messages = new[]
                    {
                        new
                        {
                            role = "user",
                            content = question
                        }
                    }
                };

                var response = await _httpClient.PostAsJsonAsync(
                    _config["EndPoint"],
                    requestBody);

                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.Answer = $"API Error:\n{result}";
                    ViewBag.Question = question;
                    return View("Index");
                }

                using var doc = JsonDocument.Parse(result);

                if (!doc.RootElement.TryGetProperty("choices", out var choices))
                {
                    ViewBag.Answer = $"Unexpected Response:\n{result}";
                    ViewBag.Question = question;
                    return View("Index");
                }

                var answer = choices[0]
                    .GetProperty("message")
                    .GetProperty("content")
                    .GetString();

                ViewBag.Question = question;
                ViewBag.Answer = answer;

                return View("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Question = question;
                ViewBag.Answer = ex.Message;

                return View("Index");
            }
        }
    }
}