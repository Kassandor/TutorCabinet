using System.Data.Common;
using System.Security.Claims;
using TutorCabinet.Application.DTOs;
using TutorCabinet.Application.DTOs.Users;
using TutorCabinet.Application.Interfaces.Services;
using TutorCabinet.Core.Entities;
using TutorCabinet.Core.Interfaces;
using TutorCabinet.Core.Interfaces.Persistence.Repositories;
using TutorCabinet.Core.ValueObjects;

namespace TutorCabinet.Application.Services;

/// <summary>
/// <inheritdoc cref="IUserService"/>
/// </summary>
/// <param name="repo"><see cref="IUserRepository"/></param>
/// <param name="hasher"><see cref="IPasswordHasher"/></param>
public class UserService(IUserRepository repo, IUnitOfWork uow, IPasswordHasher hasher)
    : IUserService
{
    public async Task<Guid> CreateAsync(CreateUserDto dto, CancellationToken cancellationToken)
    {
        var passwordHash = hasher.Hash(dto.Password);
        var user = User.Create(Guid.NewGuid(), new Email(dto.Email), dto.Name, passwordHash);

        try
        {
            await repo.AddAsync(user, cancellationToken);
            await uow.SaveChangesAsync(cancellationToken);
            return user.Id;
        }
        catch (DbException ex)
        {
            throw new InvalidOperationException("Unable to create user", ex);
        }
    }

    public async Task<UsersListDto?> GetAllAsync(CancellationToken cancellationToken)
    {
        var users = await repo.GetAllAsync(cancellationToken);
        if (users is null)
            return null;
        var usersDto = users.Select(u => new UserDto(u.Id, u.Email.Address, u.Name)).ToList();
        return new UsersListDto(usersDto, usersDto.Count);
    }

    public async Task<UserDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await repo.GetByIdAsync(id, cancellationToken);
        return user is null ? null : new UserDto(user.Id, user.Email.Address, user.Name);
    }

    public async Task<UserDto?> GetByCurrentUserAsync(
        ClaimsPrincipal user,
        CancellationToken cancellationToken
    )
    {
        var guidString = user.FindFirst("userId")?.Value;
        if (guidString is null)
            return null;
        return await GetByIdAsync(Guid.Parse(guidString), cancellationToken);
    }

    public async Task<bool> UserExistsByClaimsAsync(
        ClaimsPrincipal user,
        CancellationToken cancellationToken
    )
    {
        var guidString = user.FindFirst("userId")?.Value;
        if (guidString is null)
            return false;
        return await UserExistsAsync(Guid.Parse(guidString), cancellationToken);
    }

    public async Task<bool> UserExistsAsync(Guid id, CancellationToken cancellationToken)
    {
        return await repo.ExistsAsync(id, cancellationToken);
    }

    public async Task<bool> CheckCredentialsAsync(
        string email,
        string password,
        CancellationToken cancellationToken
    )
    {
        var user = await repo.GetByEmailAsync(email, cancellationToken);
        return user != null && user.VerifyPassword(password, hasher);
    }

    public Task UpdateAsync(UpdateUserDto dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
