using System.Text.Json.Serialization;

namespace RepertoireManagementService.Application.Common.Dtos;

public record ShowtimesResultDto
{
    [JsonPropertyName("showtimes")]
    public ShowtimesDto Showtimes { get; set; }
}
