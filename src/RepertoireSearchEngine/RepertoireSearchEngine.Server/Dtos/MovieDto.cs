namespace RepertoireSearchEngine.Server.Dtos;

public class MovieDto
{
    public string Id { get; set; }
    public string MovieTitle { get; set; }
    public string Genre { get; set; }
    public double Rating { get; set; }
    public List<DateTime> Showtimes { get; set; }
}
