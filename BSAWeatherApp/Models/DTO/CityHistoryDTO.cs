﻿using System;

namespace BSAWeatherApp.Models.DTO
{
    public class CityHistoryDTO
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public DateTime DateTimeOfSearch { get; set; }
        public bool IsSuccess { get; set; }
    }
}