using Microsoft.EntityFrameworkCore;
using TutorCabinet.Core.Interfaces.Entities;
using TutorCabinet.Core.Interfaces.Persistence;
using TutorCabinet.Core.Interfaces.Persistence.Repositories;
using TutorCabinet.Infrastructure.Persistence.Contexts;

namespace TutorCabinet.Infrastructure.Persistence.Repositories;

/// <summary>
/// <inheritdoc cref="IBaseRepository{TDomain}"/>
/// </summary>
/// <param name="ctx">Контекст базы данных"/></param>
/// <typeparam name="TEntity">Тип сущности базы данных</typeparam>
/// <typeparam name="TDomain">Тип доменной модели</typeparam>
public abstract class BaseRepository<TEntity, TDomain>(AppDbContext ctx) : IBaseRepository<TDomain>
    where TEntity : class, IEntity
    where TDomain : class, IDomain
{
    protected readonly AppDbContext Ctx = ctx;

    protected abstract TDomain ToDomain(TEntity entity);
    protected abstract TEntity ToEntity(TDomain domain);

    public virtual async Task<List<TDomain>?> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await Ctx.Set<TEntity>().ToListAsync(cancellationToken);
        return entities.Select(ToDomain).ToList();
    }

    public virtual async Task<TDomain?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await Ctx.Set<TEntity>().FindAsync([id], cancellationToken);
        return entity == null ? null : ToDomain(entity);
    }

    public virtual async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken)
    {
        return await Ctx.Set<TEntity>().AnyAsync(x => x.Id == id, cancellationToken);
    }

    public virtual async Task AddAsync(TDomain domainModel, CancellationToken cancellationToken)
    {
        var entity = ToEntity(domainModel);
        await Ctx.Set<TEntity>().AddAsync(entity, cancellationToken);
    }

    public virtual async Task DeleteAsync(TDomain domainModel, CancellationToken cancellationToken)
    {
        var entitySet = Ctx.Set<TEntity>();
        var entity = await entitySet.FindAsync([domainModel.Id], cancellationToken);
        if (entity != null)
            entitySet.Remove(entity);
    }
}
