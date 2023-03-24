using System.Text.Json.Serialization;

namespace RepertoireManagementService.Application.Common.Dtos;

public record ShowtimesDto
{
    [JsonPropertyName("movies")]
    public MovieDto[] Movies { get; set; }
}
