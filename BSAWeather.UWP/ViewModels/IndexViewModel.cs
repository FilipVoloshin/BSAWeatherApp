using GalaSoft.MvvmLight.Views;

namespace BSAWeather.UWP.ViewModels
{
    public class IndexViewModel: BaseViewModel
    {
        private INavigationService navigation;

        public IndexViewModel(INavigationService navigation)
        {
            this.navigation = navigation;
        }
    }
}
