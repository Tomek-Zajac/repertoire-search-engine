using RepertoireSearchEngine.Server.Dtos;
using RepertoireSearchEngine.Server.Services.Interfaces;
using System.Net;
using System.Text.Json;

namespace RepertoireSearchEngine.Server;

public class CinemaService : ICinemaService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public CinemaService(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
    {
        _httpClient = httpClient;
        _jsonSerializerOptions = jsonSerializerOptions;
    }

    public async Task<IEnumerable<CinemaDto>> GetCinemasAsync(
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync("/cinemas", cancellationToken);

        if (response.StatusCode is HttpStatusCode.OK)
        {
            var jsonString = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<List<CinemaDto>>(jsonString, _jsonSerializerOptions);
        }

        return default;
    }
}
