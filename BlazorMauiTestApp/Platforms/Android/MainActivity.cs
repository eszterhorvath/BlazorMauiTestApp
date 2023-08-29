using Android.App;
using Android.Content.PM;

namespace BlazorMauiTestApp
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode |
                               ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    [IntentFilter(new[] {
        "SHINY_LOCAL_NOTIFICATION_CLICK"
    })]
    public class MainActivity : MauiAppCompatActivity
    {
    }
}