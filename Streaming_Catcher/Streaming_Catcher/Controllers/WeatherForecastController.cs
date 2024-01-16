using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace Streaming_Catcher.Controllers
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
        private readonly ISubscriber _sub;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            var redis = ConnectionMultiplexer.Connect("localhost:6379");
            _sub = redis.GetSubscriber();
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            _sub.Publish("test", "Hallo");

            return Ok();
        }
    }
}