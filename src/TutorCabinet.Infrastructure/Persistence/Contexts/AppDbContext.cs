using Microsoft.EntityFrameworkCore;
using TutorCabinet.Infrastructure.Data.Configurations;
using TutorCabinet.Infrastructure.Persistence.Entities;

namespace TutorCabinet.Infrastructure.Persistence.Contexts;

/// <summary>
/// Абстрактный контекст для базы данных
/// </summary>
/// <param name="options"><see cref="DbContextOptions"/></param>
public abstract class AppDbContext(DbContextOptions options) : DbContext(options)
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
