using System;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace ConnectAPI.DI
{
    public class UnityServiceLocator : ServiceLocatorImplBase
    {
        private readonly IUnityContainer _container;

        public UnityServiceLocator(IUnityContainer container)
        {
            _container = container;
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return _container.ResolveAll(serviceType);
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            return _container.Resolve(serviceType, key);
        }
    }
}
