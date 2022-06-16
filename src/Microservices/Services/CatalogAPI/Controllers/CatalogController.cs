using CatalogAPI.Data.Context;
using CatalogAPI.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<CatalogController> _logger;
        private readonly CatalogDbContext _context;

        public CatalogController(ILogger<CatalogController> logger, CatalogDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Product> Get()
        {
            return _context.Products.ToList();
        }
    }
}