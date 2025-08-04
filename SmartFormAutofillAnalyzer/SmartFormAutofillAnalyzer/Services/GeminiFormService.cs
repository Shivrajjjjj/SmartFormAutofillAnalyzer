using System.Net.Http;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace SmartFormAutofillAnalyzer.Services
{
    public class GeminiFormService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public GeminiFormService(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _apiKey = configuration["Gemini:ApiKey"];
        }

        public async Task<Dictionary<string, string>> AnalyzeFormAsync(string userInput)
        {
            string endpoint = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key={_apiKey}";

            var requestBody = new
            {
                contents = new[]
                {
                    new {
                        parts = new[] {
                            new { text = $"Extract structured form fields from this message: \"{userInput}\". Return valid JSON with fields: name, email, address, phone, message." }
                        }
                    }
                }
            };

            var jsonRequest = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endpoint, content);
            var responseText = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Gemini API error: {response.StatusCode}\n{responseText}");
            }

            var responseJson = JsonDocument.Parse(responseText);
            var candidates = responseJson.RootElement.GetProperty("candidates");

            if (candidates.GetArrayLength() > 0)
            {
                var text = candidates[0].GetProperty("content").GetProperty("parts")[0].GetProperty("text").GetString();
                var start = text.IndexOf('{');
                var end = text.LastIndexOf('}');
                if (start >= 0 && end > start)
                {
                    var json = text.Substring(start, end - start + 1);
                    return JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                }
            }

            return new Dictionary<string, string>();
        }
    }
}
