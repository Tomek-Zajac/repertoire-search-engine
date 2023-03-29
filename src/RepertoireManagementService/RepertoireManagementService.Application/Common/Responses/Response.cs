namespace RepertoireManagementService.Application.Common.Responses;

public record Response<T>
{
    public T Data { get; init; }
    public bool Success { get; init; }
    public string ErrorMessage { get; init; }
}
