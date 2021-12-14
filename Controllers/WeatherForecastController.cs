using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PFEBackend.Models;
using System.Security.Claims;

namespace PFEBackend.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("WeatherForecast")]
    public class WeatherForecastController : ControllerBase
    {
        private VinciMarketContext _context;
        private IConfiguration _configuration;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, VinciMarketContext context, IConfiguration config)
        {
            _logger = logger;
            _context = context;
            _configuration = config;
        }

        [HttpGet]
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

        [HttpGet("/free")]
        [AllowAnonymous]
        public IEnumerable<WeatherForecast> GetFree()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("/config")]
        [AllowAnonymous]
        public string? GetConfig()
        {
            return _configuration.GetConnectionString("DB");
        }

        [HttpGet("/administrator")]
        [Authorize(Roles = "administrator")]
        public IEnumerable<WeatherForecast> GetVIP()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        
        [HttpGet("/me")]
        [AllowAnonymous]
        public string GetMe()
        {
            return User.FindFirst("preferred_username")?.Value + "    " + User.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value;
        }

        [HttpGet("/claims")]
        [AllowAnonymous]
        public IEnumerable<Claim> GetClaims()
        {
            return User.Claims;
        }
    }
}