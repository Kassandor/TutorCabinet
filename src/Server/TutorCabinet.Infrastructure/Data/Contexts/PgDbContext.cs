using Microsoft.EntityFrameworkCore;
using TutorCabinet.Infrastructure.Data.Configurations;
using TutorCabinet.Infrastructure.Data.Models;

namespace TutorCabinet.Infrastructure.Data.Contexts;

/// <summary>
/// Контекст базы данных PostgreSQL
/// </summary>
/// <param name="options"><inheritdoc cref="AppDbContext"/></param>
public class PgDbContext(DbContextOptions<PgDbContext> options) : AppDbContext(options)
{
    /// <summary>
    /// Коллекция объектов <see cref="UserEntity"/>
    /// </summary>
    public DbSet<UserEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
    }
}