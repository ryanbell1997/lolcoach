namespace LolCoach.API.Options;

public class RiotOptions
{
    [ConfigurationKeyName("ApiKey")]
    public required string ApiKey { get; set; }

    [ConfigurationKeyName("Region")]
    public required string Region { get; set; }
}
