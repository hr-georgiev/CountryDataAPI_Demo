using CountryData.API.Models;

namespace CountryData.API.Extensions
{
    public static class CountryListExtensions
    {
        public static IEnumerable<Country> FilterByName(this IEnumerable<Country> countries, string? search)
        {
            if (search is null)
            {
                return countries;
            }

            return countries.Where(c => c.Name.Common.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        public static IEnumerable<Country> FilterByPopulationSize(this IEnumerable<Country> countries, int sizeInMillions)
        {
            if (sizeInMillions <= 0)
            {
                return countries;
            }

            return countries.Where(c => c.Population <= (sizeInMillions * 1_000_000));
        }

        public static IEnumerable<Country> SortByName(this IEnumerable<Country> countries, string? direction)
        {
            if (direction is null)
            {
                return countries;
            }

            if (direction == "ascending")
            {
                return countries.OrderBy((c) => c.Name.Common);
            }

            if (direction == "descending")
            {
                return countries.OrderByDescending((c) => c.Name.Common);
            }

            throw new ArgumentOutOfRangeException(nameof(direction));
        }

        public static IEnumerable<Country> Limit(this IEnumerable<Country> countries, int limit)
        {
            if (limit > 0)
            {
                return countries.Take(limit);
            }

            return countries;
        }
    }
}
