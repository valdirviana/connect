using ConnectAPI.App.App;
using ConnectAPI.Domain.App;
using Microsoft.Practices.Unity;

namespace ConnectAPI.DI
{
    public class AppRegister
    {
        private AppRegister() { }

        public static void Register(IUnityContainer container)
        {
            container.RegisterType<IFuncionarioApp, FuncionarioApp>(new HierarchicalLifetimeManager());
            container.RegisterType<IFaltasApp, FaltasApp>(new HierarchicalLifetimeManager());
            container.RegisterType<IFeriasApp, FeriasApp>(new HierarchicalLifetimeManager());
        }
    }
}
