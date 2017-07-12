using BSAWeatherApp.Models;
using BSAWeatherApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace BSAWeatherApp.Helpers
{
    public class HistoryHelper
    {
        public IEnumerable<HistoryViewModel> GetCityRequestCount(IEnumerable<CityHistory> cityHistory)
        {
            var groupedValues = cityHistory
                .GroupBy(c => c.CityName.ToLower(),
                (key, values) => new
                {
                    CityName = key,
                    Count = values.Count(),
                    LastDayOfSearch = values.OrderByDescending(c => c.DateTimeOfSearch).FirstOrDefault().DateTimeOfSearch
                })
                .AsEnumerable();

            var historyList = new List<HistoryViewModel>();
            foreach (var value in groupedValues)
            {
                historyList.Add(new HistoryViewModel
                {
                    City = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.CityName),
                    CountOfRequests = value.Count,
                    LastDateOfSearch = value.LastDayOfSearch
                });
            }
            return historyList;
        }
    }
}