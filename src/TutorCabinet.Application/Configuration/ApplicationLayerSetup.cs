using Microsoft.Extensions.DependencyInjection;
using TutorCabinet.Application.Interfaces.Services;
using TutorCabinet.Application.Services;

namespace TutorCabinet.Application.Configuration;

public static class ApplicationLayerSetup
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        // Services
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IDirectionStudyService, DirectionStudyService>();
    }
}
