using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dependencies;

namespace WebChat.Unity
{
    public class UnityDependencyScope : IDependencyScope
    {
        protected readonly IUnityContainer Container;

        public UnityDependencyScope(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            Container = container;
        }

        public object GetService(Type serviceType)
        {
            if (typeof(IHttpController).IsAssignableFrom(serviceType))
            {
                return Container.Resolve(serviceType);
            }

            if (Container.IsRegistered(serviceType))
            {
                return Container.Resolve(serviceType);
            }

            return null;
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
}