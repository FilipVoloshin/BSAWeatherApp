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
            navigationService.Configure(nameof(IndexViewModel), typeof(IndexView));

            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            SimpleIoc.Default.Register<IndexViewModel>();

            ServiceLocator.Current.GetInstance<IndexViewModel>();
        }

        public IndexViewModel IndexVMInstance
        {
            get { return ServiceLocator.Current.GetInstance<IndexViewModel>(); }
        }

    }
}
