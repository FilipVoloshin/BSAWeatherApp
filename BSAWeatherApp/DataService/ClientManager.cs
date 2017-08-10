using BSAWeatherApp.Identity;
using BSAWeatherApp.Models.IdentityEntities;
using BSAWeatherApp.Context;

namespace BSAWeatherApp.DataService
{
    public class ClientManager : IClientManager
    {
        public BSARegistrationContext Database { get; set; }

        public ClientManager(BSARegistrationContext db)
        {
            Database = db;
        }

        public void Create(ClientProfile user)
        {
            Database.ClientProfiles.Add(user);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}