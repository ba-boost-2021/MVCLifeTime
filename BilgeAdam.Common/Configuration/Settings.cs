namespace BilgeAdam.Common.Configuration
{
    public class Settings
    {
        public DatabaseSettings Database { get; set; }
        public WeatherApiSettings Weather { get; set; }
    }

    public class DatabaseSettings
    {
        public string ConnectionString { get; set; }
    }

    public class WeatherApiSettings
    {
        public string Url { get; set; }
        public string Key { get; set; }
    }
}