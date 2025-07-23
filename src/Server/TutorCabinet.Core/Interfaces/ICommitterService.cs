namespace TutorCabinet.Core.Interfaces;

/// <summary>
/// Коммиттер в базу данных
/// </summary>
public interface ICommitterService
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
}