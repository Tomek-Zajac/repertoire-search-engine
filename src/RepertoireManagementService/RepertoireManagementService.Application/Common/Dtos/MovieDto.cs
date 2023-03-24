using System.Text.Json.Serialization;

namespace RepertoireManagementService.Application.Common.Dtos;

public record MovieDto
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("showtimes")]
    public ShowtimeDto[] Showtimes { get; set; }
}