using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TutorCabinet.Application.Interfaces;
using TutorCabinet.Application.Services;
using TutorCabinet.Core.Interfaces;
using TutorCabinet.Core.Interfaces.Persistence.Repositories;
using TutorCabinet.Infrastructure.ExternalServices;
using TutorCabinet.Infrastructure.Persistence.Contexts;
using TutorCabinet.Infrastructure.Persistence.Repositories;
using TutorCabinet.Infrastructure.Persistence.UnitOfWork;
using TutorCabinet.Infrastructure.Services;

namespace TutorCabinet.Infrastructure.Configuration;

public static class InfrastructureLayerSetup
{
    /// <summary>
    /// Регистрация сервисов инфраструктуры в DI
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    /// <param name="configuration"><see cref="IConfiguration"/></param>
    /// <returns></returns>
    public static void AddInfrastructureLayer(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContextPool<AppDbContext, PgDbContext>(options =>
        {
            options
                .UseNpgsql(configuration.GetConnectionString("PgDatabase"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        // Internal Services
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUnitOfWork, EfUnitOfWork>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IJwtProvider, JwtProvider>();

        // Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IDirectionStudyRepository, DirectionStudyRepository>();

        // External Services
        // Hasher паролей
        services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();
    }
}
