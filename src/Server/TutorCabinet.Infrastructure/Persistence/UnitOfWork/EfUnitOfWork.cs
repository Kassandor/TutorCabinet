using Microsoft.EntityFrameworkCore.Storage;
using TutorCabinet.Core.Interfaces;
using TutorCabinet.Infrastructure.Persistence.Contexts;

namespace TutorCabinet.Infrastructure.Persistence.UnitOfWork;

/// <summary>
/// <inheritdoc cref="IUnitOfWork"/>
/// </summary>
public sealed class EfUnitOfWork(AppDbContext ctx) : IUnitOfWork, IAsyncDisposable
{
    private IDbContextTransaction? _transaction;

    public async Task BeginTransactionAsync(CancellationToken cancellationToken)
    {
        _transaction ??= await ctx.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken) =>
        await ctx.SaveChangesAsync(cancellationToken);


    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        if (_transaction is null) return;
        try
        {
            await _transaction.CommitAsync(cancellationToken);
        }
        finally
        {
            await DisposeTransactionAsync();
        }
    }

    public async Task RollbackAsync(CancellationToken cancellationToken)
    {
        if (_transaction is null) return;
        try
        {
            await _transaction.RollbackAsync(cancellationToken);
        }
        finally
        {
            await DisposeTransactionAsync();
        }
    }

    /// <summary>
    /// Освобождение транзакции
    /// </summary>
    private async ValueTask DisposeTransactionAsync()
    {
        if (_transaction is null) return;
        await _transaction.DisposeAsync();
        _transaction = null;
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeTransactionAsync();
    }
}