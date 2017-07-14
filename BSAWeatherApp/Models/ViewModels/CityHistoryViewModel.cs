using System;

namespace BSAWeatherApp.Models.ViewModels
{
    public class CityHistoryViewModel
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public DateTime DateTimeOfSearch { get; set; }
    }
}