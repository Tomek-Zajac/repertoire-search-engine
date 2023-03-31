namespace RepertoireManagementService.Application.Modules.Cinemas.Dtos;

public record MovieDto
{
    public string Id { get; init; }
    public string MovieTitle { get; init; }
    public List<string> Showtimes { get; init; }
    public string ImageUrl { get; init; }
}