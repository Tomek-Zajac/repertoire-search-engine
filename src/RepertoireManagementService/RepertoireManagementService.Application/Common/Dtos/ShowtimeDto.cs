using System.Text.Json.Serialization;

namespace RepertoireManagementService.Application.Common.Dtos;

public record ShowtimeDto
{
    [JsonPropertyName("time")]

    public string Time { get; init; }
    [JsonPropertyName("tickets_url")]
    public string TicketsUrl { get; init; }
}
