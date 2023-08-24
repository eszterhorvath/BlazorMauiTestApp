using BlazorMauiTestApp.Data;
using BlazorMauiTestApp.Shiny;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shiny.Jobs;

namespace BlazorMauiTestApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseShiny()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddSingleton<IWeatherDataStore>(new WeatherDataStore());
            
            builder.Services.AddJob(typeof(LoadWeatherDataJob), "LoadWeatherDataJob");

            return builder.Build();
        }
    }
}