namespace CountryData.API.Models.CountryData
{
    public record InternationalDialingData
    {
        public string Root { get; init; }

        public string[] Suffixes { get; init; } 
    }
}
