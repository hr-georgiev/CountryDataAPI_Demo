namespace CountryData.API.Models
{
    public record OperationResult<T>(bool isSuccess, T Result, string? errorMessage = null) where T : class
    {
    }
}
