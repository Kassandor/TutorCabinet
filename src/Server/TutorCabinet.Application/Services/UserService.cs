using TutorCabinet.Application.DTOs;
using TutorCabinet.Core.Entities;
using TutorCabinet.Core.Interfaces;
using TutorCabinet.Core.ValueObjects;

namespace TutorCabinet.Application.Services;

public class UserService(IUserRepository repo, IPasswordHasher hasher)
{
    public async Task<Guid> CreateAsync(CreateUserDto dto, CancellationToken cancellationToken)
    {
        var user = new User(Guid.NewGuid(), new Email(dto.Email), dto.Name);
        var hash = hasher.Hash(dto.Password);
        user.SetPassword(hash);

        await repo.AddAsync(user, cancellationToken);
        return user.Id;
    }

    public async Task<bool> CheckCredentialsAsync(string email, string password, CancellationToken cancellationToken)
    {
        var user = await repo.GetByEmailAsync(email, cancellationToken);
        return user != null && user.VerifyPassword(password, hasher);
    }
}