using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dependencies;
using AutoMapper;
using ConnectAPI.DI;
using Microsoft.Practices.Unity;

namespace Connect.API
{
    internal class UnityDependencyScope : IDependencyScope
    {
        protected IUnityContainer Container { get; }

        public UnityDependencyScope(IUnityContainer container)
        {
            Container = container;
        }

        public object GetService(Type serviceType)
        {
            if (typeof(IHttpController).IsAssignableFrom(serviceType))
            {
                return Container.Resolve(serviceType);
            }

            try
            {
                return Container.Resolve(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Container.ResolveAll(serviceType);
        }

        public void Dispose()
        {
            Container.Dispose();
        }
    }

    internal class UnityDependencyResolver : UnityDependencyScope, IDependencyResolver
    {
        public UnityDependencyResolver(IUnityContainer container) : base(container)
        {
        }

        public IDependencyScope BeginScope()
        {
            var childContainer = Container.CreateChildContainer();

            return new UnityDependencyScope(childContainer);
        }
    }

    public static class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration config, MapperConfiguration mapperConfiguration)
        {
            var container = UnityBootstrapper.Initialise(mapperConfiguration);

            config.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
