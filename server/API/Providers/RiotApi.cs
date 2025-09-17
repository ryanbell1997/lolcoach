using System.Text.Json;
using LolCoach.API.Models.Riot.Response;

namespace LolCoach.API.Providers;

public interface IRiotApi
{
    Task<GetAccountResponseDto?> GetAccountByNameAndTagline(string gameName, string tagLine, CancellationToken ct = default);
}

public class RiotApi(HttpClient httpClient) : IRiotApi
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<GetAccountResponseDto?> GetAccountByNameAndTagline(string gameName, string tagLine, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(gameName)) throw new ArgumentNullException(nameof(gameName));
        if (string.IsNullOrWhiteSpace(tagLine)) throw new ArgumentNullException(nameof(tagLine));

        var encodedGame = Uri.EscapeDataString(gameName.Trim());
        var encodedTag = Uri.EscapeDataString(tagLine.Trim());
        var url = $"/riot/account/v1/accounts/by-riot-id/{encodedGame}/{encodedTag}";
        using var response = await _httpClient.GetAsync(url, ct);
        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null; // Not found
        }

        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync(ct);
            throw new HttpRequestException($"Riot API error {(int)response.StatusCode}: {body}");
        }
        
        await using var stream = await response.Content.ReadAsStreamAsync(ct);
        var dto = await JsonSerializer.DeserializeAsync<GetAccountResponseDto>(stream, cancellationToken: ct);
        return dto;
    }
}
