using System;
using System.Threading.Tasks;
using BSAWeatherApp.Identity;
using BSAWeatherApp.Context;
using Microsoft.AspNet.Identity.EntityFramework;
using BSAWeatherApp.Models.IdentityEntities;

namespace BSAWeatherApp.DataService
{
    public class IdentityUnitOfWork : IIdentityUnitOfWork
    {
        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private IClientManager clientManager;
        private BSARegistrationContext db;

        public IdentityUnitOfWork()
        {
            db = new BSARegistrationContext();
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
            clientManager = new ClientManager(db);
        }

        public ApplicationUserManager UserManager { get { return userManager; } }

        public IClientManager ClientManager { get { return clientManager; } }

        public ApplicationRoleManager RoleManager { get { return roleManager; } }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        Task IIdentityUnitOfWork.SaveAsync()
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    userManager.Dispose();
                    roleManager.Dispose();
                    clientManager.Dispose();
                }
                disposed = true;
            }
        }
        #endregion
    }
}