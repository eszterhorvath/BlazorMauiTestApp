using BlazorMauiTestApp.Data;
using Shiny.Jobs;

namespace BlazorMauiTestApp.Shiny
{
    public class LoadWeatherDataJob : IJob
    {
        private readonly IWeatherDataStore _weatherData;

        public LoadWeatherDataJob(IWeatherDataStore weatherData)
        {
            _weatherData = weatherData;
        }

        public async Task Run(JobInfo jobInfo, CancellationToken cancelToken)
        {
            await Task.Delay(30000, cancelToken);

            var temps = new List<int>();
            for (var i = 0; i < 10; i++)
            {
                temps.Add(Random.Shared.Next(-20, 40));
            }
            _weatherData.LoadWeather(temps);
        }
    }
}
