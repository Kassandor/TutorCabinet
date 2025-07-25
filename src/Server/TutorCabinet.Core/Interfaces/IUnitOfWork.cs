namespace TutorCabinet.Core.Interfaces;

/// <summary>
/// Координатор транзакций
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Начало транзакции
    /// </summary>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task BeginTransactionAsync(CancellationToken cancellationToken);

    /// <summary>
    /// <para>Сохраняет накопленные в контексте изменения в базу данных.</para>
    /// <para>Если явная транзакция не была открыта через <see cref="BeginTransactionAsync"/>,
    /// EF Core сам создаст внутреннюю транзакцию и автоматически зафиксирует её.</para>
    /// <para>Иначе для фиксации изменений необходимо вызвать <see cref="CommitAsync"/></para>
    /// </summary>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task SaveChangesAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Коммит транзакции в базу данных
    /// </summary>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task CommitAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Отмена изменений в транзакции
    /// </summary>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task RollbackAsync(CancellationToken cancellationToken);
}