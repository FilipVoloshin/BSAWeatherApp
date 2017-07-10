using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSAWeatherApp.Models
{
    [Table("Cities")]
    public class CityModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}