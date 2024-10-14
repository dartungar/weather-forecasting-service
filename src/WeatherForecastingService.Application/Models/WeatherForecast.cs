namespace WeatherForecastingService.Application.Models;

public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary);