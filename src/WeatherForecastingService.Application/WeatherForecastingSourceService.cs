using Microsoft.Extensions.Options;
using Weather.NET;
using Weather.NET.Models.WeatherModel;

namespace WeatherForecastingService.Application;

public class WeatherForecastingSourceService : IWeatherForecastSource
{
    private readonly WeatherClient _client;

    public WeatherForecastingSourceService(IOptions<WeatherClientOptions> options)
    {
        _client = new WeatherClient(options.Value.ApiKey);
    }

    public async Task<WeatherModel> GetCurrentWeatherAsync(string cityName, CancellationToken cancellationToken = default)
    {
        return await _client.GetCurrentWeatherAsync(cityName);
    }

    public async Task<IEnumerable<WeatherModel>> GetForecastAsync(string cityName, CancellationToken cancellationToken = default)
    {
        return await _client.GetForecastAsync(cityName);
    }
}