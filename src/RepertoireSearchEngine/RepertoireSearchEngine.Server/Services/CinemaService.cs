using RepertoireSearchEngine.Server.Dtos;
using RepertoireSearchEngine.Server.Services.Interfaces;
using System.Net;
using System.Text.Json;

namespace RepertoireSearchEngine.Server;

public class CinemaService : ICinemaService
{
    private readonly HttpClient _httpClient;

    public CinemaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<CinemaDto>> GetCinemasAsync(
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync("/cinema", cancellationToken);

        if (response.StatusCode is HttpStatusCode.OK)
        {
            var jsonString = await response.Content.ReadAsStringAsync(cancellationToken);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<List<CinemaDto>>(jsonString, options);
        }

        return default;
    }
}
