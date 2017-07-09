using BSAWeatherApp.Models;

namespace BSAWeatherApp.Services
{
    public interface IForecastProvider
    {
        Forecast GetWeatherForecastObject(string url);
        WeatherNow GetWeatherNowObject(string url);
    }
}
