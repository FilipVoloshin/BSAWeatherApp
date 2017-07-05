using BSAWeatherApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace BSAWeatherApp.Services
{
    public class WeatherForecast
    {
        public const string APIKEY = "d2a17a94d01097989a3e2d5e1cd799a8";

        public WeatherForcast GetWeatherForecast(string city, string period)
        {
            string cnt = ""; //period in days
            switch (period)
            {
                case "forToday":
                    cnt = "1";
                    break;
                case "forThreeDays":
                    cnt = "3";
                    break;
                case "forWeek":
                    cnt = "7";
                    break;
                default:
                    throw new KeyNotFoundException();
            }
            string url = $"http://api.openweathermap.org/data/2.5/forecast/daily?q={city}&cnt={cnt}&APPID={APIKEY}&units=metric";
            var client = new WebClient();
            var json = client.DownloadString(url);
            return JsonConvert.DeserializeObject<WeatherForecast>(json);
        }
    }
}