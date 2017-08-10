using BSAWeatherApp.Models.IdentityEntities;
using System;

namespace BSAWeatherApp.Identity
{
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
    }
}
