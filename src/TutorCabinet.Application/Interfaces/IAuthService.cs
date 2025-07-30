using TutorCabinet.Application.DTOs;

namespace TutorCabinet.Application.Interfaces;

public interface IAuthService
{
    Task<string?> LoginAsync(AuthUserDto userDto, CancellationToken cancellationToken);
}