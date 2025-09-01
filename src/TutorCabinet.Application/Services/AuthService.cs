using TutorCabinet.Application.DTOs;
using TutorCabinet.Application.Interfaces;
using TutorCabinet.Core.Interfaces;
using TutorCabinet.Core.Interfaces.Persistence.Repositories;

namespace TutorCabinet.Application.Services;

public class AuthService(IUserRepository userRepo, IJwtProvider jwtProvider, IPasswordHasher hasher)
    : IAuthService
{
    public async Task<TokenPair?> LoginAsync(
        AuthUserDto userDto,
        CancellationToken cancellationToken
    )
    {
        var user = await userRepo.GetByEmailAsync(userDto.Email, cancellationToken);
        if (user is null || !user.VerifyPassword(userDto.Password, hasher))
            return null;
        return jwtProvider.GenerateTokens(user);
    }

    public async Task<TokenPair?> RefreshTokenAsync(
        RefreshTokenDto dto,
        CancellationToken cancellationToken
    )
    {
        var email = jwtProvider.GetEmailFromToken(dto.RefreshToken);
        if (email is null)
            return null;
        var user = await userRepo.GetByEmailAsync(email, cancellationToken);
        return user is null ? null : jwtProvider.GenerateTokens(user);
    }
}
