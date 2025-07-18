using Microsoft.EntityFrameworkCore;

namespace TutorCabinet.Infrastructure.Data;

public abstract class AppDbContext(DbContextOptions options) : DbContext(options);