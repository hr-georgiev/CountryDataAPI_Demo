using System.Text.Json.Serialization;

namespace CountryData.API.Models.CountryData
{
    public record CarInfo
    {
        [JsonPropertyName("signs")]
        public string[] RegistrationSignPrefixes { get; init; } = Array.Empty<string>();

        [JsonPropertyName("side")]
        public string DrivingSide { get; init; } = string.Empty;
    }
}
