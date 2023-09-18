using CountryData.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CountryData.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CountriesController : ControllerBase
    {
        private const string RestCountriesAllEndpoint = "https://restcountries.com/v3.1/all";

        private readonly ILogger<CountriesController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public CountriesController(ILogger<CountriesController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet(Name = "GetCountries")]
        public async Task<IEnumerable<Country>> Get([FromQuery] int population = 0, [FromQuery] string? name = null, [FromQuery] string? sortDirection = null)
        {
            using HttpClient client = _httpClientFactory.CreateClient();
            var countries = await client.GetFromJsonAsync<IEnumerable<Country>>(RestCountriesAllEndpoint);
            
            return countries ?? Enumerable.Empty<Country>();
        }
    }
}
