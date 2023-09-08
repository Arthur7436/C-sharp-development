using Microsoft.AspNetCore.Mvc;

namespace MiniAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 2).Select(index => new WeatherForecast
        {
            Date = "07/09/2023",
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = "This is the summary section",
            Age = 24,
            RandomProperty = "This is a random property I added to the JSON"

        })
        .ToArray();
    }
}
