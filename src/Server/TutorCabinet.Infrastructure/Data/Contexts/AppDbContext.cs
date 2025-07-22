using Microsoft.EntityFrameworkCore;

namespace TutorCabinet.Infrastructure.Data.Contexts;

public abstract class AppDbContext(DbContextOptions options) : DbContext(options);