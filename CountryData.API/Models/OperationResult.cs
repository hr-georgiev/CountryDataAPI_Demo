namespace CountryData.API.Models
{
    public record OperationResult<T>(T Result, bool IsSuccess = true, string? ErrorMessage = null) where T : class
    {
    }
}
