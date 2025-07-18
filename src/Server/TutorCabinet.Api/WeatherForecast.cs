namespace TutorCabinet.Api;

public readonly record struct WeatherForecast
{
    public DateOnly Date { get; init; }

    public int TemperatureC { get; init; }

    public string? Summary { get; init; }
}