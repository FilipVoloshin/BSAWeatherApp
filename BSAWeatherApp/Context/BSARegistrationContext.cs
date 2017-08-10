using BSAWeatherApp.Models.IdentityEntities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace BSAWeatherApp.Context
{
    public class BSARegistrationContext : IdentityDbContext<ApplicationUser>
    {
        public BSARegistrationContext()
            : base("name=DefaultConnection")
        {
        }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
    }
}