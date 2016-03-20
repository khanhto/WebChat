using Microsoft.AspNet.SignalR;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;

namespace WebChat.Unity
{
    public class HubUnityDependencyResolver : DefaultDependencyResolver
    {
        private readonly IUnityContainer Container;

        public HubUnityDependencyResolver(IUnityContainer container)
        {
            Container = container;
        }

        public override object GetService(Type serviceType)
        {
            if (typeof(Hub).IsAssignableFrom(serviceType))
            {
                return Container.Resolve(serviceType);
            }

            if (Container.IsRegistered(serviceType))
            {
                return Container.Resolve(serviceType);
            }

            return base.GetService(serviceType);
        }

        public override IEnumerable<object> GetServices(Type serviceType)
        {
            if (Container.IsRegistered(serviceType))
            {
                Container.ResolveAll(serviceType);
            }

            return base.GetServices(serviceType);
        }
    }
}