using BSAWeather.UWP.Models;
using BSAWeather.UWP.Services;
using GalaSoft.MvvmLight.Views;

namespace BSAWeather.UWP.ViewModels
{
    public class IndexViewModel: BaseViewModel
    {
        private INavigationService navigation;
        private IClientService<Forecast> forecastService;
        private IClientService<CurrentWeather> currentWeatherService;

        public IndexViewModel(INavigationService navigation)
        {
            this.navigation = navigation;
            forecastService = new ClientService<Forecast>();
            currentWeatherService = new ClientService<CurrentWeather>();
        }
    }
}
