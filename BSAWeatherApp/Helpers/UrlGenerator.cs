using System;
using System.Configuration;

namespace BSAWeatherApp.Helpers
{
    public class UrlGenerator
    {
        private string _defaultCity;
        private string _customCity;
        private string _daysCount;

        public UrlGenerator(string defaultCity, string customCity, string daysCount)
        {
            _defaultCity = defaultCity;
            _customCity = customCity;
            _daysCount = daysCount;
        }
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

        public string GenerateUrlByFilterSettings()
        {
            string cnt = _daysCount; // period in days
            string q = _customCity == null || _customCity == "" ? _defaultCity : _customCity;
            string url = $"{BaseUrl}/forecast/daily?q={q}&cnt={cnt}&APPID={ApiKey}&units=metric";
            return url;

        }
    }
}