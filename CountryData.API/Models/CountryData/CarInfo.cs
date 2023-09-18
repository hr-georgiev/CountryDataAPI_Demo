using System.Text.Json.Serialization;

namespace CountryData.API.Models.CountryData
{
    public record CarInfo
    {
        [JsonPropertyName("signs")]
        public string[] RegistrationSignPrefixes { get; init; }

        [JsonPropertyName("side")]
        public string DrivingSide { get; init; }
    }
}
