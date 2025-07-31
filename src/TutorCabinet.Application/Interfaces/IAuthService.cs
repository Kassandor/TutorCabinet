using TutorCabinet.Application.DTOs;

namespace TutorCabinet.Application.Interfaces;

public interface IAuthService
{
    Task<TokenPair?> LoginAsync(AuthUserDto userDto, CancellationToken cancellationToken);
    Task<TokenPair?> RefreshTokenAsync(RefreshTokenDto dto, CancellationToken cancellationToken);
}