namespace RepertoireSearchEngine.Server.Dtos;

public class SittingDto
{
    public string Name { get; set; }
    public double Price { get; set; }
    public List<SeatDto> Seats { get; set; }
}
