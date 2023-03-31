namespace RepertoireSearchEngine.Server.Dtos;

public class MovieDto
{
    public string Id { get; set; }
    public string MovieTitle { get; set; }
    public List<string> Showtimes { get; set; }
    public string ImageUrl { get; set; }
}
