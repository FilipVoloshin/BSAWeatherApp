using BSAWeatherApp.Models;
using System.Data.Entity;

namespace BSAWeatherApp.Context
{
    public class BSAWeatherContext : DbContext
    {
        public BSAWeatherContext()
            :base("name=DefaultConnection")
        {
        }

        public DbSet<CityModel> Cities { get; set; }
    }
}