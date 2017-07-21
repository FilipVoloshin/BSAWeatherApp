using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BSAWeatherApp.Models.ViewModels
{
    public class SettingsViewModel
    {
        public IEnumerable<CityViewModel> Cities { get; set; }
        public IEnumerable<CityHistoryViewModel> CityHistory { get; set; }
        public IEnumerable<CityStatisticViewModel> SearchStatistic { get; set; }
    }
}