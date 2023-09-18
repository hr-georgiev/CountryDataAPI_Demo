using System.Text.Json.Serialization;

namespace CountryData.API.Models
{
    public class ImageSource
    {
        [JsonPropertyName("png")]
        public string PngUrl { get; init; }

        [JsonPropertyName("svg")]
        public string SvgUrl { get; init; }
    }
}
