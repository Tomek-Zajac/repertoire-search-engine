namespace RepertoireManagementService.Application.Modules.Cinemas.Dtos;

public record SeatDto
{
    public string Id { get; init; }
    public string Row { get; init; }
    public List<string> Seats { get; init; }
}
