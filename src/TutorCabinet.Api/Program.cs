using TutorCabinet.Api.Configuration;
using TutorCabinet.Application.Configuration;
using TutorCabinet.Infrastructure.Configuration;

namespace TutorCabinet.Api;

public static class Program
{
    public static void Main(string[] args)
    {
        // Main settings
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;
        var environment = builder.Environment;

        // Optional settings
        const string localConfigPath = "localConfig.json";
        configuration.AddLocalConfiguration(localConfigPath);

        builder.Services.AddApiLayer(configuration);
        builder.Services.AddApplicationLayer();
        builder.Services.AddInfrastructureLayer(configuration);
        builder.Services.AddApiCors(configuration);

        if (environment.IsDevelopment())
        {
            builder.Services.AddApiDocumentation();
        }

        var app = builder.Build();
        app.UseApiMiddleware();
        app.MapControllers();

        if (environment.IsDevelopment())
        {
            app.UseApiDocumentation();
        }

        app.Run();
    }
}
