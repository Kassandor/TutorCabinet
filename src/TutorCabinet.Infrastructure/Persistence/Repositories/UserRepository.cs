using Microsoft.EntityFrameworkCore;
using TutorCabinet.Core.Entities;
using TutorCabinet.Core.Interfaces.Persistence.Repositories;
using TutorCabinet.Core.ValueObjects;
using TutorCabinet.Infrastructure.Persistence.Contexts;
using TutorCabinet.Infrastructure.Persistence.Entities;

namespace TutorCabinet.Infrastructure.Persistence.Repositories;

/// <summary>
/// <inheritdoc cref="BaseRepository{TEntity,TDomain}"/>
/// </summary>
public class UserRepository(AppDbContext ctx)
    : BaseRepository<UserEntity, User>(ctx),
        IUserRepository
{
    protected override User ToDomain(UserEntity entity)
    {
        return User.Get(
            entity.Id,
            new Email(entity.Email),
            entity.Name,
            entity.PasswordHash,
            entity.CreatedAt,
            entity.UpdatedAt
        );
    }

    protected override UserEntity ToEntity(User user)
    {
        return new UserEntity()
        {
            Id = user.Id,
            Email = user.Email.Address,
            Name = user.Name,
            CreatedAt = user.CreatedAt,
            PasswordHash = user.PasswordHash,
        };
    }

    public async Task<User?> GetByEmailAsync(
        string email,
        CancellationToken cancellationToken = default
    )
    {
        var entity = await Ctx.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        return entity == null ? null : ToDomain(entity);
    }

    public async Task UpdateAsync(User user, CancellationToken cancellationToken = default)
    {
        var entity = await Ctx.Users.FindAsync([user.Id], cancellationToken);
        if (entity == null)
            throw new KeyNotFoundException($"User with Id = {user.Id} not found");
        entity.Email = user.Email.Address;
        entity.Name = user.Name;
        entity.PasswordHash = user.PasswordHash;
        entity.UpdatedAt = user.UpdatedAt;
    }
}
