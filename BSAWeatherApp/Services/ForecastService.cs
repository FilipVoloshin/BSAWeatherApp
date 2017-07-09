using BSAWeatherApp.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Configuration;

namespace BSAWeatherApp.Services
{
    public class ForecastProvider
    {
        public Forecast GetWeatherForecast(string defaultCity, string customCity, string periods)
        {
            var apiKey = ConfigurationManager.AppSettings["API"];
            var baseUrl = ConfigurationManager.AppSettings["URL"];

            string cnt = periods; // period in days
            string q = customCity == null || customCity == "" ? defaultCity : customCity;
            string url = $"{baseUrl}/forecast/daily?q={q}&cnt={cnt}&APPID={apiKey}&units=metric";
            var client = new HttpClient();
            var json = client.GetStringAsync(url).Result;
            var jsonObject = JsonConvert.DeserializeObject<Forecast>(json);
            return jsonObject;
        }
    }
}