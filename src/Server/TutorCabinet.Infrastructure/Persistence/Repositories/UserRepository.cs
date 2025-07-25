using Microsoft.EntityFrameworkCore;
using TutorCabinet.Core.Entities;
using TutorCabinet.Core.Interfaces;
using TutorCabinet.Core.ValueObjects;
using TutorCabinet.Infrastructure.Data.Models;
using TutorCabinet.Infrastructure.Persistence.Contexts;

namespace TutorCabinet.Infrastructure.Persistence.Repositories;

/// <summary>
/// <inheritdoc cref="IUserRepository"/>
/// </summary>
/// <param name="ctx">Контекст базы данных <see cref="PgDbContext"/></param>
public class UserRepository(AppDbContext ctx) : IUserRepository
{
    public async Task<List<User>?> GetAllAsync(CancellationToken cancellationToken)
    {
        var userEntities = await ctx.Users.ToListAsync(cancellationToken);
        var users = userEntities.Select(e => new User(e.Id, new Email(e.Email), e.Name));
        return users.ToList();
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await ctx.Users.FindAsync([id], cancellationToken);
        return entity == null
            ? null
            : new User(id, new Email(entity.Email), entity.Name) { CreatedAt = entity.CreatedAt };
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        var entity = await ctx.Users
            .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        return entity == null
            ? null
            : new User(entity.Id, new Email(entity.Email), entity.Name)
            {
                CreatedAt = entity.CreatedAt,
                PasswordHash = entity.PasswordHash
            };
    }

    public async Task AddAsync(User user, CancellationToken cancellationToken = default)
    {
        var entity = new UserEntity
        {
            Id = user.Id,
            Email = user.Email.Address,
            Name = user.Name,
            CreatedAt = user.CreatedAt,
            PasswordHash = user.PasswordHash
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
        if (entity != null) ctx.Users.Remove(entity);
    }
}