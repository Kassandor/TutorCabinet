using TutorCabinet.Application.DTOs;
using TutorCabinet.Application.Interfaces;
using TutorCabinet.Core.Entities;
using TutorCabinet.Core.Interfaces;
using TutorCabinet.Core.ValueObjects;

namespace TutorCabinet.Application.Services;
/// <summary>
/// <inheritdoc cref="IUserService"/>
/// </summary>
/// <param name="repo"><see cref="IUserRepository"/></param>
/// <param name="hasher"><see cref="IPasswordHasher"/></param>
public class UserService(IUserRepository repo, IPasswordHasher hasher) : IUserService
{
    public async Task<Guid> CreateAsync(CreateUserDto dto, CancellationToken cancellationToken)
    {
        var user = new User(Guid.NewGuid(), new Email(dto.Email), dto.Name);
        var hash = hasher.Hash(dto.Password);
        user.SetPassword(hash);

        await repo.AddAsync(user, cancellationToken);
        return user.Id;
    }

    public async Task<UserDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await repo.GetByIdAsync(id, cancellationToken);
        if (user is null) return null;
        return new UserDto
        {
            Id = user.Id,
            Email = user.Email.Address,
            Name = user.Name,
        };
    }

    public async Task<bool> CheckCredentialsAsync(string email, string password, CancellationToken cancellationToken)
    {
        var user = await repo.GetByEmailAsync(email, cancellationToken);
        return user != null && user.VerifyPassword(password, hasher);
    }

    public Task UpdateAsync(UpdateUserDto dto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}