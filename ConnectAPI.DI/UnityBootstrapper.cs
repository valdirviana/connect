using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace ConnectAPI.DI
{
    public class UnityBootstrapper
    {
        protected UnityBootstrapper() { }

        private static MapperConfiguration _mapperConfiguration;

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        }

        private static void RegisterTypes(IUnityContainer container)
        {
            AutoMapperRegister.Register(container, _mapperConfiguration);

            RepositoryRegister.Register(container);
            AppRegister.Register(container);
        }

        public static IUnityContainer Initialise(MapperConfiguration mapperConfiguration)
        {
            _mapperConfiguration = mapperConfiguration;
            var container = BuildUnityContainer();
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));
            return container;
        }
    }
}
