using BSAWeather.UWP.Models;
using BSAWeather.UWP.View;
using BSAWeather.UWP.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace BSAWeather.UWP
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var navigationService = new NavigationService();
            navigationService.Configure(nameof(CityViewModel), typeof(CityView));
            navigationService.Configure(nameof(CurrentWeatherViewModel), typeof(CurrentWeatherView));
            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
        }

    }
}
