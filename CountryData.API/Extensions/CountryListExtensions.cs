using CountryData.API.Models;
using System.Linq;

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

            return countries.Where(c => c.Name.Common.Contains(search, StringComparison.OrdinalIgnoreCase));
        }

        public static IEnumerable<Country> FilterByPopulationSize(this IEnumerable<Country> countries, int? sizeInMillions)
        {
            if (sizeInMillions is null)
            {
                return countries;
            }

            if (sizeInMillions <= 0)
            {
                return Enumerable.Empty<Country>();
            }

            return countries.Where(c => c.Population <= checked(sizeInMillions * 1_000_000));
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

        public static IEnumerable<Country> Limit(this IEnumerable<Country> countries, int? limit)
        {
            if (limit is null)
            {
                return countries;
            }

            return countries.Take(limit.Value);
        }
    }
}
