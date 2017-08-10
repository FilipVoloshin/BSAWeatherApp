using BSAWeatherApp.Identity;
using System;
using System.Threading.Tasks;

namespace BSAWeatherApp.DataService
{
    public interface IIdentityUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();
    }
}