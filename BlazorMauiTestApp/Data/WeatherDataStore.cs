namespace BlazorMauiTestApp.Data
{
    public interface IWeatherDataStore
    {
        public List<int> GetWeather(int days);
        public void LoadWeather(List<int> temperatures);
    }

    public class WeatherDataStore : IWeatherDataStore
    {
        private readonly List<int> _temperatures;

        public WeatherDataStore()
        {
            _temperatures = new List<int>();
        }

        public List<int> GetWeather(int days)
        {
            return _temperatures.Count >= days
                ? _temperatures.GetRange(0, days)
                : _temperatures;
        }

        public void LoadWeather(List<int> temperatures)
        {
            _temperatures.AddRange(temperatures);
        }
    }
}
