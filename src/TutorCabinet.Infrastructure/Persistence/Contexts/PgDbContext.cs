using Microsoft.EntityFrameworkCore;

namespace TutorCabinet.Infrastructure.Persistence.Contexts;

/// <summary>
/// Контекст базы данных PostgreSQL
/// </summary>
/// <param name="options"><inheritdoc cref="AppDbContext"/></param>
public class PgDbContext(DbContextOptions<PgDbContext> options) : AppDbContext(options);
