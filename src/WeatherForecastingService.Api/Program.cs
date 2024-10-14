using WeatherForecastingService.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<WeatherClientOptions>(
    builder.Configuration.GetSection(nameof(WeatherClientOptions)));
builder.Services.AddTransient<IWeatherForecastSource, WeatherForecastingSourceService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/current", async (string cityName, IWeatherForecastSource source) =>
    {
        var forecast = await source.GetCurrentWeatherAsync(cityName);
        return forecast;
    })
    .WithName("GetCurrentWeather")
    .WithOpenApi();

app.MapGet("/forecast", async (string cityName, IWeatherForecastSource source) =>
    {
        var forecast = await source.GetForecastAsync(cityName);
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();
