using TutorCabinet.Application.DTOs;
using TutorCabinet.Application.Interfaces;
using TutorCabinet.Core.Interfaces;

namespace TutorCabinet.Application.Services;

public class AuthService(IUserRepository userRepo, IJwtProvider jwtProvider, IPasswordHasher hasher)
    : IAuthService
{
    public async Task<TokenPair?> LoginAsync(AuthUserDto userDto, CancellationToken cancellationToken)
    {
        var user = await userRepo.GetByEmailAsync(userDto.Email, cancellationToken);
        if (user is null || !user.VerifyPassword(userDto.Password, hasher)) return null;
        return jwtProvider.GenerateTokens(user);
    }

    public async Task<TokenPair?> RefreshTokenAsync(RefreshTokenDto dto, CancellationToken cancellationToken)
    {
        var user = await userRepo.GetByEmailAsync(dto.Email, cancellationToken);
        return user is null ? null : jwtProvider.GenerateTokens(user);
    }
}