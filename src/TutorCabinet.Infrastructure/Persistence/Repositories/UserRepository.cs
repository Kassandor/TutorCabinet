using Microsoft.EntityFrameworkCore;
using TutorCabinet.Core.Entities;
using TutorCabinet.Core.Interfaces;
using TutorCabinet.Core.ValueObjects;
using TutorCabinet.Infrastructure.Persistence.Contexts;
using TutorCabinet.Infrastructure.Persistence.Entities;

namespace TutorCabinet.Infrastructure.Persistence.Repositories;

/// <summary>
/// <inheritdoc cref="IUserRepository"/>
/// </summary>
/// <param name="ctx">Контекст базы данных <see cref="PgDbContext"/></param>
public class UserRepository(AppDbContext ctx) : IUserRepository
{
    public async Task<bool> ExistsAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await ctx.Users.AnyAsync(x => x.Id == userId, cancellationToken);
    }

    public async Task<List<User>?> GetAllAsync(CancellationToken cancellationToken)
    {
        var userEntities = await ctx.Users.ToListAsync(cancellationToken);
        var users = userEntities.Select(e =>
            User.Get(e.Id, new Email(e.Email), e.Name, e.PasswordHash, e.CreatedAt, e.UpdatedAt)
        );
        return users.ToList();
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var e = await ctx.Users.FindAsync([id], cancellationToken);
        return e == null
            ? null
            : User.Get(e.Id, new Email(e.Email), e.Name, e.PasswordHash, e.CreatedAt, e.UpdatedAt);
    }

    public async Task<User?> GetByEmailAsync(
        string email,
        CancellationToken cancellationToken = default
    )
    {
        var e = await ctx.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        return e == null
            ? null
            : User.Get(e.Id, new Email(e.Email), e.Name, e.PasswordHash, e.CreatedAt, e.UpdatedAt);
    }

    public async Task AddAsync(User user, CancellationToken cancellationToken)
    {
        var entity = new UserEntity
        {
            Id = user.Id,
            Email = user.Email.Address,
            Name = user.Name,
            CreatedAt = user.CreatedAt,
            PasswordHash = user.PasswordHash,
        };
        await ctx.Users.AddAsync(entity, cancellationToken);
    }

    public async Task UpdateAsync(User user, CancellationToken cancellationToken = default)
    {
        var entity = await ctx.Users.FindAsync([user.Id], cancellationToken);
        if (entity == null)
            throw new KeyNotFoundException($"User with Id = {user.Id} not found");
        entity.Email = user.Email.Address;
        entity.Name = user.Name;
        entity.PasswordHash = user.PasswordHash;
        entity.UpdatedAt = user.UpdatedAt;
    }

    public async Task DeleteAsync(User user, CancellationToken cancellationToken = default)
    {
        var entity = await ctx.Users.FindAsync([user.Id], cancellationToken);
        if (entity != null)
            ctx.Users.Remove(entity);
    }
}
