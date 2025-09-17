using System.Text.Json.Serialization;

namespace LolCoach.API.Models.Riot.Response;

public record GetAccountResponseDto
{
    [JsonPropertyName("puuid")]
    public required string Puuid { get; init; }

    [JsonPropertyName("gameName")]
    public required string GameName { get; init; }

    [JsonPropertyName("tagLine")]
    public required string TagLine { get; init; }
}
