using Microsoft.EntityFrameworkCore;
using TutorCabinet.Infrastructure.Data.Configurations;
using TutorCabinet.Infrastructure.Data.Models;

namespace TutorCabinet.Infrastructure.Data.Contexts;

public class PgDbContext(DbContextOptions<PgDbContext> options) : AppDbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
    }
}