using MongoDB.Bson.IO;
using RepertoireManagementService.Application.Common.Dtos;
using RepertoireManagementService.Application.Common.Interfaces;
using System.Collections;
using System.Net.Http.Json;
using System.Threading;

namespace RepertoireManagementService.Infrastructure.Services;

internal class ShowtimeService : IShowtimeService
{
    private readonly HttpClient _httpClient;

    public ShowtimeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    //public async Task<ShowtimesResultDto> GetShowtimes(CancellationToken cancellationToken = default)
    //{

    //    var requestUrl = $"/showtimes-results?api_key=5d2a6c17574e72715523132be70afce45b08afe938ed9c6d5bc5907b42ce8e94&q=eternals+theater&location=Austin,+Texas,+United+States&hl=en&gl=us";

    //    var response = await _httpClient.GetAsync(requestUrl);

    //    if (!response.IsSuccessStatusCode)
    //    {
    //        throw new Exception($"Failed to retrieve showtimes results. StatusCode: {response.StatusCode}, ReasonPhrase: {response.ReasonPhrase}");
    //    }

    //    var a = await response.Content.ReadAsStringAsync();

    //    return await response
    //        .Content
    //        .ReadFromJsonAsync<ShowtimesResultDto>(cancellationToken: cancellationToken);
    //}

    public async Task<ShowtimesResultDto> GetShowtimes(CancellationToken cancellationToken)
    {
        try
        {
            var parameters = new Dictionary<string, string>
                {
                    { "q", "eternals+theater" },
                    { "location", "Austin,+Texas,+United+States" },
                    { "hl", "en" },
                    { "gl", "us" },
                    { "api_key", "5d2a6c17574e72715523132be70afce45b08afe938ed9c6d5bc5907b42ce8e94" }
                };

            var response = await _httpClient.GetAsync("https://serpapi.com/search.json?" + BuildQueryString(parameters));

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return await response
                .Content
                .ReadFromJsonAsync<ShowtimesResultDto>(cancellationToken: cancellationToken);
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to retrieve showtimes results.", ex);
        }
    }

    private string BuildQueryString(Dictionary<string, string> parameters)
    {
        var queryString = new List<string>();

        foreach (var parameter in parameters)
        {
            queryString.Add($"{parameter.Key}={Uri.EscapeDataString(parameter.Value)}");
        }

        return string.Join("&", queryString);
    }
}