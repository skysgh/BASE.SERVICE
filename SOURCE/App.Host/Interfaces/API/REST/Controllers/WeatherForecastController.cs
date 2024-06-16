using Microsoft.AspNetCore.Mvc;

namespace App.Host.Interfaces.API.REST.Controllers
{
    /// <summary>
    /// Weather Forecast Controller.
    /// TODO: Remove
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

#pragma warning disable IDE0052 // Remove unread private members
        private readonly ILogger<WeatherForecastController> _logger;
#pragma warning restore IDE0052 // Remove unread private members

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherForecastController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
#pragma warning disable IDE0290 // Use primary constructor
        public WeatherForecastController(ILogger<WeatherForecastController> logger) => _logger = logger;
#pragma warning restore IDE0290 // Use primary constructor

        /// <summary>
        /// return a list of weather forecast items.
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
