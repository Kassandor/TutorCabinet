using TutorCabinet.Application.DTOs;
using TutorCabinet.Application.Interfaces;
using TutorCabinet.Core.Interfaces;

namespace TutorCabinet.Application.Services;

public class AuthService(IUserRepository userRepo, IJwtProvider jwtProvider, IUnitOfWork uow, IPasswordHasher hasher)
    : IAuthService
{
    public async Task<string?> LoginAsync(AuthUserDto userDto, CancellationToken cancellationToken)
    {
        var user = await userRepo.GetByEmailAsync(userDto.Email, cancellationToken);
        if (user is null || !user.VerifyPassword(userDto.Password, hasher)) return null;
        return jwtProvider.GenerateToken(user);
    }
}