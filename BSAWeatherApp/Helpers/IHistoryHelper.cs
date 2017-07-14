using BSAWeatherApp.Models.ViewModels;
using System.Collections.Generic;

namespace BSAWeatherApp.Helpers
{
    public interface IHistoryHelper
    {
        IEnumerable<CityStatisticViewModel> GetCityRequestCount(IEnumerable<CityHistoryViewModel> cityHistory);
    }
}
