using BSAWeatherApp.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace BSAWeatherApp.Services
{
    public class ForecastProvider
    {
        public Forecast GetWeatherApiObject(string url)
        {
            var client = new HttpClient();
            var json = client.GetStringAsync(url).Result;
            var jsonObject = JsonConvert.DeserializeObject<Forecast>(json);
            return jsonObject;
        }
    }
}