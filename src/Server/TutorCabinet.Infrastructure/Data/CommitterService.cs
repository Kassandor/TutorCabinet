using TutorCabinet.Core.Interfaces;
using TutorCabinet.Infrastructure.Data.Contexts;

namespace TutorCabinet.Infrastructure.Data;

/// <summary>
/// <inheritdoc cref="ICommitterService"/>
/// </summary>
/// <param name="db"><see cref="AppDbContext"/></param>
public class CommitterService(AppDbContext db) : ICommitterService
{
    public Task SaveChangesAsync(CancellationToken cancellationToken) => db.SaveChangesAsync(cancellationToken);
}