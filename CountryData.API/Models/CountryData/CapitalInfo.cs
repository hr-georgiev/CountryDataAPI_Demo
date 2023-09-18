using System.Text.Json.Serialization;

namespace CountryData.API.Models.CountryData
{
    public record CapitalInfo
    {
        [JsonPropertyName("latlng")]
        public double[] Coordinates { get; init; }
    }
}
