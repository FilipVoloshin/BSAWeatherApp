namespace BSAWeatherApp.Services
{
    public interface IUrlGenerator
    {
        string GenerateForecastUrl(string defaultCity, string customCity, string daysCount);
        string GenerateWeatherUrl(string city);
    }
}
