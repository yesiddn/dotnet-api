using Microsoft.AspNetCore.Mvc;

namespace dotnet_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static List<WeatherForecast> ListWeatherForecast = new();

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;

        if(ListWeatherForecast == null || !ListWeatherForecast.Any())
        {
            ListWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToList();
        }
    }

    [HttpGet(Name = "GetWeatherForecast")] // Name sirve para poder referenciar a este endpoint en otros lugares
    [Route("GetWeatherForecast")] // asi se declara un endpoint con un nombre especifico
    // cuando en el controlador existe un unico get, se puede acceder a el con la url base + el nombre del controlador
    [Route("Get/WeatherForecast")] // pueden existir multiples rutas para un mismo endpoint
    [Route("[action]")] // se puede acceder a este endpoint con la url base + el nombre del controlador + el nombre del metodo -> action se refiere al nombre del metodo
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogInformation("Getting weather forecast");
        return ListWeatherForecast;
    }

    [HttpPost]
    public IActionResult Post(WeatherForecast weatherForecast)
    {
        ListWeatherForecast.Add(weatherForecast);
        return Created();
    }

    [HttpDelete("{index}")]
    public IActionResult Delete(int index)
    {
        if (ListWeatherForecast.Count <= index)
        {
            return BadRequest("The given ID is out of bounds.");
        }

        ListWeatherForecast.RemoveAt(index);
        return Ok("Forecast was successfully removed.");
    }
}
