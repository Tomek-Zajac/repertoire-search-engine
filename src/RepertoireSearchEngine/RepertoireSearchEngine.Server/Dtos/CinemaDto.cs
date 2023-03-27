namespace RepertoireSearchEngine.Server.Dtos;

public class CinemaDto
{
    public string Id { get; set; }
    public string CinemaName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public List<RepertoireDto> Repertoire { get; set; }
}