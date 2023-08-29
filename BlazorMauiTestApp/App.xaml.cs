using Shiny.Jobs;

namespace BlazorMauiTestApp
{
    public partial class App : Application
    {
        private readonly IJobManager _jobManager;

        public App(IJobManager jobManager)
        {
            _jobManager = jobManager;
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override async void OnStart()
        {
            base.OnStart();
#if IOS
            await _jobManager.Run("LoadWeatherDataJob");
#endif
        }
    }
}