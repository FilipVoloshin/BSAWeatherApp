using System;
using System.Configuration;

namespace BSAWeatherApp.Services
{
    public class UrlGenerator : IUrlGenerator
    {
        public string BaseUrl
        {
            get
            {
                var url = ConfigurationManager.AppSettings["URL"];
                if (url == null)
                    throw new ArgumentNullException("Configuration settings for url are incorrect!");
                if (url == String.Empty)
                    throw new ArgumentException("Empty value in URL settings!");
                return url;
            }
        }
        public string ApiKey
        {
            get
            {
                var apiKey = ConfigurationManager.AppSettings["API"];
                if (apiKey == null)
                    throw new ArgumentNullException("Configuration settings for API key are incorrect!");
                if (apiKey == String.Empty)
                    throw new ArgumentException("Empty value in API key settings!");
                return apiKey;
            }
        }

        public string GenerateForecastUrl(string defaultCity, string customCity, string daysCount)
        {
            string url = defaultCity == String.Empty ?
                $"{BaseUrl}/forecast/daily?q={customCity}&cnt={daysCount}&APPID={ApiKey}&units=metric" :
                $"{BaseUrl}/forecast/daily?q={defaultCity}&cnt={daysCount}&APPID={ApiKey}&units=metric";
            return url;
        }

        public string GenerateWeatherUrl(string city)
        {
            return $"{BaseUrl}/weather?q={city}&APPID={ApiKey}&units=metric";
        }
    }
}