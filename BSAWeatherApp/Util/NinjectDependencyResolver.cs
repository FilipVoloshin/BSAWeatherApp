using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using BSAWeatherApp.Services;
using BSAWeatherApp.DataService;
using BSAWeatherApp.Models;

namespace BSAWeatherApp.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IForecastProvider>().To<ForecastProvider>();
            kernel.Bind<IUrlGenerator>().To<UrlGenerator>();
            kernel.Bind(typeof(IRepository<CityModel>)).To<CitiesRepository>();
        }
    }
}