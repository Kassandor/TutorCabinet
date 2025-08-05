using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using TutorCabinet.Application.Configuration;

namespace TutorCabinet.Api.Configuration;

public static class ApiLayerSetup
{
    /// <summary>
    /// Добавление локального конфиг файла "localConfig.json"
    /// </summary>
    /// <param name="configuration"><see cref="IConfigurationManager"/></param>
    /// <param name="path">Путь к файлу относительно проекта</param>
    public static void AddLocalConfiguration(this IConfigurationManager configuration, string path)
    {
        if (File.Exists(path))
            configuration.AddJsonFile(path, optional: true, reloadOnChange: true);
    }

    /// <summary>
    /// Расширение для регистрации сервисов API слоя.
    /// Добавляет настройку JWT аутентификации, авторизации и контроллеров.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    /// <param name="configuration"><see cref="IConfiguration"/></param>
    public static void AddApiLayer(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtOptions = configuration.GetSection("JwtOptions").Get<JwtOptions>();

        if (jwtOptions is null) return;
        services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey))
                };
            });
        services.AddAuthorization();
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        });
    }

    /// <summary>
    /// Добавляет политику CORS с разрешёнными хостами из конфигурации.
    /// Если список пуст, никто не будет иметь доступа.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    /// <param name="configuration"><see cref="IConfiguration"/></param>
    public static void AddApiCors(this IServiceCollection services, IConfiguration configuration)
    {
        var allowedHosts = configuration.GetSection("AllowedHosts").Get<string[]>() ?? [];

        services.AddCors(options =>
            options.AddPolicy("AllowedHosts",
                policy => policy.WithOrigins(allowedHosts).AllowAnyMethod().AllowAnyHeader()));
    }

    /// <summary>
    /// Добавляет в конвейер обработки запросов стандартные middleware для API
    /// </summary>
    /// <param name="app"><see cref="IApplicationBuilder"/></param>
    public static void UseApiMiddleware(this IApplicationBuilder app)
    {
        app.UseCors("AllowedHosts");
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
    }

    /// <summary>
    /// Регистрирует сервисы OpenAPI (Swagger) для генерации документации API.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    public static void AddApiDocumentation(this IServiceCollection services)
    {
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        services.AddOpenApi();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    /// <summary>
    /// Добавляет middleware для отображения Swagger UI и OpenAPI эндпоинтов в конвейер.
    /// </summary>
    /// <param name="app"><see cref="WebApplication"/></param>
    public static void UseApiDocumentation(this WebApplication app)
    {
        app.MapOpenApi();
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}