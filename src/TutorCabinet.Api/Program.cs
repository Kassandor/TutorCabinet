using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TutorCabinet.Application.Configuration;
using TutorCabinet.Application.Interfaces;
using TutorCabinet.Application.Services;
using TutorCabinet.Core.Interfaces;
using TutorCabinet.Infrastructure.ExternalServices;
using TutorCabinet.Infrastructure.Persistence.Contexts;
using TutorCabinet.Infrastructure.Persistence.Repositories;
using TutorCabinet.Infrastructure.Persistence.UnitOfWork;
using TutorCabinet.Infrastructure.Services;

namespace TutorCabinet.Api;

public static class Program
{
    public static void Main(string[] args)
    {
        // Main settings
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;
        var environment = builder.Environment;
        var allowedHosts = configuration.GetSection("AllowedHosts").Get<string[]>() ?? [];
        const string localConfigFilePath = "localConfig.json";

        if (File.Exists(localConfigFilePath))
            configuration.AddJsonFile(localConfigFilePath, optional: true, reloadOnChange: true);

        var jwtOptions = configuration.GetSection("JwtOptions").Get<JwtOptions>() ?? null;

        if (jwtOptions is not null)
        {
            builder.Services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
        }

        builder.Services.AddAuthorization();
        builder.Services.AddControllers();
        builder.Services.AddDbContextPool<AppDbContext, PgDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("PgDatabase"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        // CORS policy
        builder.Services.AddCors(options =>
            options.AddPolicy("AllowedHosts",
                policy => policy.WithOrigins(allowedHosts).AllowAnyMethod().AllowAnyHeader()));

        // Internal Services
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IJwtProvider, JwtProvider>();

        // Repositories
        builder.Services.AddScoped<IUserRepository, UserRepository>();

        // External Services
        // Hasher паролей
        builder.Services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();

        if (environment.IsDevelopment())
        {
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }

        var app = builder.Build();
        app.UseCors("AllowedHosts");
        app.MapControllers();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();

        // Configure the HTTP request pipeline.
        if (environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.Run();
    }
}