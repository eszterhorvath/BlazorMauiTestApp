using BlazorMauiTestApp.Data;
using Shiny;
using Shiny.Jobs;
using Shiny.Notifications;
using Notification = Shiny.Notifications.Notification;

namespace BlazorMauiTestApp.Shiny
{
    public class LoadWeatherDataJob : IJob
    {
        private readonly IWeatherDataStore _weatherData;
        private readonly INotificationManager _notificationManager;

        public LoadWeatherDataJob(IWeatherDataStore weatherData, INotificationManager notificationManager)
        {
            _weatherData = weatherData;
            _notificationManager = notificationManager;
        }

        public async Task Run(JobInfo jobInfo, CancellationToken cancelToken)
        {
            await Task.Delay(5000, cancelToken);

            var temps = new List<int>();
            for (var i = 0; i < 10; i++)
            {
                temps.Add(Random.Shared.Next(-20, 40));
            }
            _weatherData.LoadWeather(temps);
            var n = new Notification
            {
                Title = "Finished loading weather data!",
                Message = "Check it out."
            };
            var result = await _notificationManager.RequestRequiredAccess(n);
            if (result != AccessState.Available)
            {
                // TODO
            }
            else
            {
                await _notificationManager.Send(n);
            }
        }
    }
}
