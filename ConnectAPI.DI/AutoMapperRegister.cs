using AutoMapper;
using Microsoft.Practices.Unity;

namespace ConnectAPI.DI
{
    public class AutoMapperRegister
    {
        private AutoMapperRegister() { }

        public static void Register(IUnityContainer container, MapperConfiguration mapperConfiguration)
        {
            var mapper = mapperConfiguration.CreateMapper();
            container.RegisterInstance(mapper);
        }
    }
}
