namespace RepertoireManagementService.Application.Modules.Cinemas.Dtos;

public record SittingDto
{
    public string Name { get; init; }
    public double Price { get; init; }
    public List<SeatDto> Seats { get; init; }
}

