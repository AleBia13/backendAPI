using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.IO;
using OpenAI_API.Moderation;
using backendAPI.Jsons.Model;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace backendAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Pacient")]
        public async Task<IActionResult> OpenAi(int id)
        {
            var path = "Jsons/ApiKey.json";
            try
            {
                var text = System.IO.File.ReadAllText(path);
                var apiKey = JsonSerializer.Deserialize<ApiKeyModel>(text);
                var openAi = new OpenAI();
                openAi.ApiKey = apiKey.OpenAI.ApiKey;
                string apiUrl = "https://api.openai.com/v1/engines/davinci/completions"; // Example URL for completions API

                string prompt = "Once upon a time";

                using (HttpClient client = new HttpClient())
                {
                    // Set the OpenAI API key in the Authorization header
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey.OpenAI.ApiKey}");

                    // Prepare the data for the request
                    var requestData = new
                    {
                        prompt,
                        max_tokens = 50
                    };

                    // Convert the data to JSON
                    string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);

                    // Create a StringContent object with the JSON data
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    try
                    {
                        // Send a POST request to the OpenAI API
                        HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                        // Check if the request was successful (status code 200-299)
                        if (response.IsSuccessStatusCode)
                        {
                            // Read and display the response content (the generated text)
                            string responseContent = await response.Content.ReadAsStringAsync();
                            Console.WriteLine(responseContent);
                        }
                        else
                        {
                            Console.WriteLine($"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Exception: {ex.Message}");
                    }
                }


            }
            catch (Exception ex)
            {
                var e = ex;
            }
            return Ok();
        }
    }
}