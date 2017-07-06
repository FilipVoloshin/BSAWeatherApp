using System;
using System.Collections.Generic;

namespace BSAWeatherApp.Models
{ 

    public class ForecastViewModel
    {
        public string CityName { get; set; }
        public string Country { get; set; }
        public List<Forecasts> WeatherForecast { get; set; }
    }

    public class Forecasts
    {
        public DateTime Date { get; set; }
        public Temperature Temperature { get; set; }
        public Weathers Weather { get; set; }
    }

    public class Temperature
    {
        public double MorningTemp { get; set; }
        public double DayTemp { get; set; }
        public double EveningTemp { get; set; }
        public double NightTemp { get; set; }
        public double MinTemp { get; set; }
        public double MaxTemp { get; set; }
    }

    public class Weathers
    {
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }



    

    
}