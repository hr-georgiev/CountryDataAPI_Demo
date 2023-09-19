using CountryData.API.Models.CountryData;
using System.Text.Json.Serialization;

namespace CountryData.API.Models
{
    public record Country
    {
        public Name Name { get; init; } = new Name();

        public string[] Capital { get; init; } = Array.Empty<string>();

        [JsonPropertyName("tld")]
        public string[] TopLevelDomain { get; init; } = Array.Empty<string>();

        public Dictionary<string, NameData> Translations { get; init; } = new();

        public Dictionary<string, CurrencyData> Currencies { get; init; } = new();

        public int Population { get; init; }

        [JsonPropertyName("cca2")]
        public string IsoAlpha2Code { get; init; } = string.Empty;

        [JsonPropertyName("cca3")]
        public string IsoAlpha3Code { get; init; } = string.Empty;

        [JsonPropertyName("ccn3")]
        public string IsoNumericCode { get; init; } = string.Empty;

        public string Status { get; init; } = string.Empty;

        [JsonPropertyName("independent")]
        public bool IsIndependent { get; init; }

        [JsonPropertyName("unMember")]
        public bool IsUNMember { get; init; }

        [JsonPropertyName("idd")]
        public InternationalDialingData Dialing { get; init; } = new();

        [JsonPropertyName("altSpellings")]
        public string[] AlternativeSpellings { get; init; } = Array.Empty<string>();

        public string Region { get; init; } = string.Empty;

        public string Subregion { get; init; } = string.Empty;

        public Dictionary<string, string> Languages { get; init; } = new();

        [JsonPropertyName("latlng")]
        public double[] Coordinates { get; init; } = Array.Empty<double>();

        public bool Landlocked { get; init; }

        [JsonPropertyName("borders")]
        public string[] BorderCountriesCodes { get; init; } = Array.Empty<string>();

        public double Area { get; init; }

        [JsonPropertyName("demonyms")]
        public Dictionary<string, Demonym> DemonymsTranslations { get; init; } = new();

        public string Flag { get; init; } = string.Empty;

        public Dictionary<string, string> Maps { get; init; } = new();

        [JsonPropertyName("gini")]
        public Dictionary<string, double> GiniIndexCoefficienPerYear { get; set; } = new();

        [JsonPropertyName("fifa")]
        public string FifaCode { get; init; } = string.Empty;

        [JsonPropertyName("car")]
        public CarInfo CarInfo { get; init; } = new();

        public string[] Timezones { get; init; } = Array.Empty<string>();

        public string[] Continents { get; init; } = Array.Empty<string>();

        public ImageSource Flags { get; init; } = new();

        public ImageSource CoatOfArms { get; init; } = new();

        public string StartOfWeek { get; init; } = string.Empty;

        public CapitalInfo CapitalInfo { get; init; } = new();
    }
}
