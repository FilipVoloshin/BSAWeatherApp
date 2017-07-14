using BSAWeatherApp.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace BSAWeatherApp.Helpers
{
    public class HistoryHelper : IHistoryHelper
    {
        public IEnumerable<CityStatisticViewModel> GetCityRequestCount(IEnumerable<CityHistoryViewModel> cityHistory)
        {
            var statisticList = new List<CityStatisticViewModel>();
            var groupedValues = cityHistory
                .GroupBy(c => c.CityName.ToLower(),
                (key, values) => new
                {
                    CityName = key,
                    Count = values.Count(),
                    LastDayOfSearch = values.OrderByDescending(c => c.DateTimeOfSearch).FirstOrDefault().DateTimeOfSearch
                }).ToList();
            groupedValues.ForEach(g =>
            {
                statisticList.Add(new CityStatisticViewModel
                {
                    City = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(g.CityName),
                    CountOfRequests = g.Count,
                    LastDateOfSearch = g.LastDayOfSearch
                });
            });
            return statisticList;
        }
    }
}