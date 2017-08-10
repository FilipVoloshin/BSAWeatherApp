using BSAWeatherApp.Models.IdentityEntities;
using Microsoft.AspNet.Identity;

namespace BSAWeatherApp.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
                : base(store)
        {
        }
    }
}