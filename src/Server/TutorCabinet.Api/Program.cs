using Microsoft.EntityFrameworkCore;
using TutorCabinet.Application.Interfaces;
using TutorCabinet.Application.Services;
using TutorCabinet.Core.Interfaces;
using TutorCabinet.Infrastructure.Data;
using TutorCabinet.Infrastructure.Data.Contexts;
using TutorCabinet.Infrastructure.Data.Repositories;
using TutorCabinet.Infrastructure.ExternalServices;

namespace TutorCabinet.Api;

public static class Program
{
    public static void Main(string[] args)
    {
        // DI container, configuration, environment
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;
        var environment = builder.Environment;
        
        builder.Services.AddAuthorization();
        builder.Services.AddControllers();
        builder.Services.AddDbContext<AppDbContext, PgDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("PgDatabase"));
        });

        // Internal Services
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<ICommitterService, CommitterService>();

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
        app.MapControllers();
        app.UseHttpsRedirection();
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