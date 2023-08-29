namespace BlazorMauiTestApp.Data
{
    public class WeatherForecastService
    {
        private readonly IWeatherDataStore _weatherData;

        public WeatherForecastService(IWeatherDataStore weatherData)
        {
            _weatherData = weatherData;
        }

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            var days = 5;
            var temps = _weatherData.GetWeather(days);
            days = temps.Count;
            return Task.FromResult(Enumerable.Range(0, days).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = temps[index],
                Summary = WeatherForecastService.GetSummary(temps[index])
            }).ToArray());
        }

        private static string GetSummary(int temperature)
        {
            return temperature switch
            {
                < -5 => "Freezing",
                >= -5 and < -2 => "Chilly",
                >= 2 and < 10 => "Cool",
                >= 10 and < 18 => "Mild",
                >= 18 and < 25 => "Warm",
                >= 25 and < 32 => "Hot",
                >= 32 => "Sweltering"
            };
        }
    }
}