using Microsoft.EntityFrameworkCore;

namespace TutorCabinet.Infrastructure.Data;

public class PgDbContext(DbContextOptions<PgDbContext> options) : AppDbContext(options);