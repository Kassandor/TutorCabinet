using Microsoft.EntityFrameworkCore;
using TutorCabinet.Core.Interfaces;
using TutorCabinet.Infrastructure.Data.Contexts;
using TutorCabinet.Infrastructure.ExternalServices;

namespace TutorCabinet.Api;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;
        var environment = builder.Environment;

        // Add services to the container.
        builder.Services.AddAuthorization();
        builder.Services.AddControllers();
        builder.Services.AddDbContext<PgDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("PgDatabase"));
        });
        
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