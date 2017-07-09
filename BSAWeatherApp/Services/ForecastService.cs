using BSAWeatherApp.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace BSAWeatherApp.Services
{
    public class ForecastProvider : IForecastProvider
    {
        public Forecast GetWeatherForecastObject(string url)
        {
            var client = new HttpClient();
            var json = client.GetStringAsync(url).Result;
            Forecast jsonObject = JsonConvert.DeserializeObject<Forecast>(json);
            return jsonObject;
        }

        public WeatherNow GetWeatherNowObject(string url)
        {
            var client = new HttpClient();
            var json = client.GetStringAsync(url).Result;
            WeatherNow jsonObject = JsonConvert.DeserializeObject<WeatherNow>(json);
            return jsonObject;
        }

    }
}