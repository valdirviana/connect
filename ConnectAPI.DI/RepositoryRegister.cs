using ConnectAPI.Domain.Base.Interface;
using ConnectAPI.Repository;
using Microsoft.Practices.Unity;

namespace ConnectAPI.DI
{
    public class RepositoryRegister
    {
        private RepositoryRegister()
        {
        }

        public static void Register(IUnityContainer container)
        {
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
        }
    }
}
