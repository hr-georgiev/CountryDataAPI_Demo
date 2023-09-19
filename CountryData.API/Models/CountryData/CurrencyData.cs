namespace CountryData.API.Models.CountryData
{
    public record CurrencyData
    {
        public string Name { get; init; } = string.Empty;

        public string Symbol { get; init; } = string.Empty;
    }
}
