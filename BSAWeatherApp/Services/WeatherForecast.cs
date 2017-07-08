using BSAWeatherApp.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace BSAWeatherApp.Services
{
    public class WeatherForecast
    {
        public const string APIKEY = "d2a17a94d01097989a3e2d5e1cd799a8";

        public Forecast GetWeatherForecast(string defaultCity, string customCity, string periods)
        {
            string cnt = periods; // period in days
            string q = customCity == null || customCity == "" ? defaultCity : customCity;
            string url = $"http://api.openweathermap.org/data/2.5/forecast/daily?q={q}&cnt={cnt}&APPID={APIKEY}&units=metric";
            try
            {
                var client = new HttpClient();
                var json = client.GetStringAsync(url).Result;
                var jsonObject = JsonConvert.DeserializeObject<Forecast>(json);
                return jsonObject;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}