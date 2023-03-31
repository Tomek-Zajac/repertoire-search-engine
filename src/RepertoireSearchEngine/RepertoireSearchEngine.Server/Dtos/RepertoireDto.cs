namespace RepertoireSearchEngine.Server.Dtos;

public class RepertoireDto
{
    public string Id { get; set; }
    public List<MovieDto> Movies { get; set; }
    public List<SittingDto> Sittings { get; set; }
}