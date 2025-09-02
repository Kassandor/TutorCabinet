using Microsoft.EntityFrameworkCore;
using TutorCabinet.Infrastructure.Persistence.Configurations;
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
    public DbSet<StudentEntity> Students { get; set; }
    public DbSet<DirectionStudyEntity> DirectionStudies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new StudentEntityConfig());
        modelBuilder.ApplyConfiguration(new DirectionStudyEntityConfig());
    }
}
