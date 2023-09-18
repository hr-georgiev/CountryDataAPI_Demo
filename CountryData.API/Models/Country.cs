using CountryData.API.Models.CountryData;
using System.Text.Json.Serialization;

namespace CountryData.API.Models
{
    public record Country
    {
        public Name Name { get; init; }

        public string[] Capital { get; init; }

        [JsonPropertyName("tld")]
        public string[] TopLevelDomain { get; init; }
        
        public Dictionary<string, NameData> Translations { get; init; }

        public Dictionary<string, CurrencyData> Currencies { get; init; }

        public int Population { get; init; }

        [JsonPropertyName("cca2")]
        public string IsoAlpha2Code { get; init; }

        [JsonPropertyName("cca3")]
        public string IsoAlpha3Code { get; init; }

        [JsonPropertyName("ccn3")]
        public string IsoNumericCode { get; init; }

        public string Status { get; init; }

        [JsonPropertyName("independent")]
        public bool IsIndependent { get; init; }

        [JsonPropertyName("unMember")]
        public bool IsUNMember { get; init; }

        [JsonPropertyName("idd")]
        public InternationalDialingData Dialing { get; init; }

        [JsonPropertyName("altSpellings")]
        public string[] AlternativeSpellings { get; init; }

        public string Region { get; init; }

        public string Subregion { get; init; }

        public Dictionary<string, string> Languages { get; init; }

        [JsonPropertyName("latlng")]
        public double[] Coordinates { get; init; }

        public bool Landlocked { get; init; }

        [JsonPropertyName("borders")]
        public string[] BorderCountriesCodes { get; init; }

        public double Area { get; init; }

        [JsonPropertyName("demonyms")]
        public Dictionary<string, Demonym> DemonymsTranslations { get; init; }

        public string Flag { get; init; }

        public Dictionary<string, string> Maps { get; init; }

        [JsonPropertyName("gini")]
        public Dictionary<string, double> GiniIndexCoefficienPerYear { get; set; }

        [JsonPropertyName("fifa")]
        public string FifaCode { get; init; }

        [JsonPropertyName("car")]
        public CarInfo CarInfo { get; init; }

        public string[] Timezones { get; init; }

        public string[] Continents { get; init; } 

        public ImageSource Flags { get; init; }

        public ImageSource CoatOfArms { get; init; }

        public string StartOfWeek { get; init; }

        public CapitalInfo CapitalInfo { get; init; }
    }
}
