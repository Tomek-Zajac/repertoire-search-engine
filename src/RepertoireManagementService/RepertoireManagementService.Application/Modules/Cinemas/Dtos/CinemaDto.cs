namespace RepertoireManagementService.Application.Modules.Cinemas.Dtos;

public record CinemaDto
{
    public string Id { get; init; }
    public string CinemaName { get; init; }
    public string Address { get; init; }
    public string City { get; init; }
    public string State { get; init; }
    public string ZipCode { get; init; }
    public List<RepertoireDto> Repertoire { get; init; }
}