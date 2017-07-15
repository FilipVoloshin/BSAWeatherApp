using BSAWeatherApp.Services;
using NUnit.Framework;

namespace BSAWeatherApp.Tests.ServicesTests
{
    [TestFixture]
    public class UrlGeneratorTests
    {
        [Test]
        public void Generator_Check_For_Correct_Generating_Url_String_For_Weather_Forecast()
        {
            //Arrange
            var url = "http://api.openweathermap.org/data/2.5/forecast/daily?q=Kiev&cnt=7&APPID=d2a17a94d01097989a3e2d5e1cd799a8&units=metric";
            //Act
            var generator = new UrlGenerator();
            var actualUrl = generator.GenerateForecastUrl("Kiev", "Uman", "7");
            //Assert
            Assert.That(actualUrl, Is.EqualTo(url));
        }
        [Test]
        public void Generator_Check_For_Correct_Generating_Url_String_For_Daily_Weather()
        {
            //Arrange
            var url = "http://api.openweathermap.org/data/2.5/weather?q=Kiev&APPID=d2a17a94d01097989a3e2d5e1cd799a8&units=metric";
            //Act
            var generator = new UrlGenerator();
            var actualUrl = generator.GenerateWeatherUrl("Kiev");
            //Assert
            Assert.That(actualUrl, Is.EqualTo(url));
        }

        [Test]
        public void Generator_Check_If_Configuration_Files_Are_Correct()
        {
            //Arrange
            var baseUrl = "http://api.openweathermap.org/data/2.5";
            var apiKey = "d2a17a94d01097989a3e2d5e1cd799a8";
            //Act
            var generator = new UrlGenerator();
            var actualBaseUrl = generator.BaseUrl;
            var actualApiKey = generator.ApiKey;

            Assert.That(actualApiKey, Is.EqualTo(apiKey));
            Assert.That(actualBaseUrl, Is.EqualTo(baseUrl));
        }
    }
}
