namespace TutorCabinet.Application.Configuration;

public sealed record JwtOptions
{
    public string SecretKey { get; init; }
    public string Issuer { get; init; }
    public string Audience { get; init; }
    public int AccessExpireHours { get; init; }
    public int RefreshExpireHours { get; init; }
}