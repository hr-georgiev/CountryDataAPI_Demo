using System.Text.Json.Serialization;

namespace CountryData.API.Models.CountryData
{
    public record Demonym
    {
        [JsonPropertyName("m")]
        public string Male { get; init; }

        [JsonPropertyName("f")]
        public string Female { get; init; }
    }
}
