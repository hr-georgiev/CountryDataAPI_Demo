using CountryData.API.Extensions;
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
        public async Task<OperationResult<IEnumerable<Country>>> Get(
            [FromQuery] int population = 0,
            [FromQuery] int limit = 0,
            [FromQuery] string? name = null,
            [FromQuery] string? sortDirection = null)
        {
            using HttpClient client = _httpClientFactory.CreateClient();            

            try
            {
                var countries = await client.GetFromJsonAsync<IEnumerable<Country>>(RestCountriesAllEndpoint);

                if (countries is null)
                {
                    return new OperationResult<IEnumerable<Country>>(
                        false,
                        Enumerable.Empty<Country>(),
                        "Failed to fetch countries");
                }

                List<Country> processedList = countries
                .FilterByPopulationSize(population)
                .FilterByName(name)
                .SortByName(sortDirection)
                .Limit(limit)
                .ToList();

                return new OperationResult<IEnumerable<Country>>(true, processedList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return new OperationResult<IEnumerable<Country>>(
                        false,
                        Enumerable.Empty<Country>(),
                        ex.Message);
            }
        }
    }
}
