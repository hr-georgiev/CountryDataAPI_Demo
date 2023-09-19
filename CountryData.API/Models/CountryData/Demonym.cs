using System.Text.Json.Serialization;

namespace CountryData.API.Models.CountryData
{
    public record Demonym
    {
        [JsonPropertyName("m")]
        public string Male { get; init; } = string.Empty;

        [JsonPropertyName("f")]
        public string Female { get; init; } = string.Empty;
    }
}
