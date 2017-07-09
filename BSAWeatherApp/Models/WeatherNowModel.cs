using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BSAWeatherApp.Models
{
        public class Main
        {
            public double Temp { get; set; }
            public double Pressure { get; set; }
            public double Humidity { get; set; }
            public double Temp_min { get; set; }
            public double Temp_max { get; set; }
        }

        public class Wind
        {
            public double Speed { get; set; }
            public double Deg { get; set; }
        }

        public class Clouds
        {
            public double All { get; set; }
        }

        public class Sys
        {
            public double Type { get; set; }
            public double Id { get; set; }
            public double Message { get; set; }
            public string Country { get; set; }
            public double Sunrise { get; set; }
            public double Sunset { get; set; }
        }

        public class WeatherNow
        {
            public Coord Coord { get; set; }
            public List<Weather> Weather { get; set; }
            public string Base { get; set; }
            public Main Main { get; set; }
            public double Visibility { get; set; }
            public Wind Wind { get; set; }
            public Clouds Clouds { get; set; }
            public double Dt { get; set; }
            public Sys Sys { get; set; }
            public double Id { get; set; }
            public string Name { get; set; }
            public double Cod { get; set; }
        }
}