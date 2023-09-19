namespace CountryData.API.Models.CountryData
{
    public record InternationalDialingData
    {
        public string Root { get; init; } = string.Empty;

        public string[] Suffixes { get; init; } = Array.Empty<string>();
    }
}
