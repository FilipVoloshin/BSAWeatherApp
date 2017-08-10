using Microsoft.AspNet.Identity.EntityFramework;

namespace BSAWeatherApp.Models.IdentityEntities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}