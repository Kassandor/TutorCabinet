using Microsoft.EntityFrameworkCore;

namespace TutorCabinet.Infrastructure.Data.Contexts;

/// <summary>
/// Абстрактный контекст для базы данных
/// </summary>
/// <param name="options"><see cref="DbContextOptions"/></param>
public abstract class AppDbContext(DbContextOptions options) : DbContext(options);