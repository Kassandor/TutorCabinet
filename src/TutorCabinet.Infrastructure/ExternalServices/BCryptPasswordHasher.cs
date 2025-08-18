using TutorCabinet.Core.Interfaces;

namespace TutorCabinet.Infrastructure.ExternalServices;

/// <summary>
/// <inheritdoc cref="IPasswordHasher"/>
/// </summary>
public class BCryptPasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool Verify(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }
}
