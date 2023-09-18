namespace CountryData.API.Models.CountryData
{
    public record Name : NameData
    {
        public Dictionary<string, NameData> NativeName { get; init; }
    }
}
