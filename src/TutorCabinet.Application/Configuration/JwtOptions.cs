namespace TutorCabinet.Application.Configuration;

public sealed record JwtOptions
{
    public required string SecretKey { get; init; }
    public required string Issuer { get; init; }
    public required string Audience { get; init; }
    public required int AccessExpireHours { get; init; }
    public required int RefreshExpireHours { get; init; }
}