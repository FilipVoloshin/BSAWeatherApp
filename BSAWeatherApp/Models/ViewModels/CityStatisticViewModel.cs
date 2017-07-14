﻿using System;

namespace BSAWeatherApp.Models.ViewModels
{
    public class CityStatisticViewModel
    {
        public string City { get; set; }
        public int CountOfRequests { get; set; }
        public DateTime LastDateOfSearch { get; set; }
    }
}