using System.Security.Claims;
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
public class UserService(
    IUserRepository repo,
    IUnitOfWork uow,
    IPasswordHasher hasher,
    IJwtProvider jwtProvider
) : IUserService
{
    public async Task<Guid> CreateAsync(CreateUserDto dto, CancellationToken cancellationToken)
    {
        var passwordHash = hasher.Hash(dto.Password);
        var user = User.Create(Guid.NewGuid(), new Email(dto.Email), dto.Name, passwordHash);

        await uow.BeginTransactionAsync(cancellationToken);
        try
        {
            await repo.AddAsync(user, cancellationToken);
            await uow.SaveChangesAsync(cancellationToken);
            await uow.CommitAsync(cancellationToken);
        }
        catch
        {
            await uow.RollbackAsync(cancellationToken);
        }

        return user.Id;
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
        var accessToken = user.FindFirst("accessToken")?.Value;
        if (accessToken is null)
            return null;
        var guidFromToken = jwtProvider.GetUserIdFromToken(accessToken);
        if (guidFromToken is null)
            return null;
        return await GetByIdAsync(guidFromToken.Value, cancellationToken);
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
