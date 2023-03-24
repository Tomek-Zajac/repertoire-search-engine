namespace RepertoireSearchEngine.Server.Dtos;

public class RepertoireDto
{
    public string MovieTitle { get; set; }
    public string Genre { get; set; }
    public double Rating { get; set; }
    public List<DateTime> Showtimes { get; set; }
}
