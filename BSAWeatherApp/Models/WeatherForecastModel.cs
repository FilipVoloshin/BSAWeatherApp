﻿using System.Collections.Generic;

namespace BSAWeatherApp.Models
{
    public class Coord
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Coord Coord { get; set; }
        public string Country { get; set; }
        public double Population { get; set; }
    }

    public class Temp
    {
        public double Day { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Night { get; set; }
        public double Eve { get; set; }
        public double Morn { get; set; }
    }

    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class List
    {
        public int Dt { get; set; }
        public Temp Temp { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }
        public List<Weather> Weather { get; set; }
        public double Speed { get; set; }
        public double Deg { get; set; }
        public double? Clouds { get; set; }
        public double? Rain { get; set; }
    }

    public class Forecast
    {
        public City City { get; set; }
        public string Cod { get; set; }
        public double Message { get; set; }
        public double Cnt { get; set; }
        public List<List> List { get; set; }
    }
}