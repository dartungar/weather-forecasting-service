using Weather.NET.Models.WeatherModel;

namespace WeatherForecastingService.Application;

public interface IWeatherForecastSource
{
    public Task<WeatherModel> GetCurrentWeatherAsync(string cityName, CancellationToken cancellationToken = default);
    public Task<IEnumerable<WeatherModel>> GetForecastAsync(string cityName, CancellationToken cancellationToken = default);
}