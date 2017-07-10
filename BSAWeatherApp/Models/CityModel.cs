using System.ComponentModel.DataAnnotations;

namespace BSAWeatherApp.Models
{
    public class CityModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}