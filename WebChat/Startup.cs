using Owin;
using Microsoft.Owin;
using System.Web.Http;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using WebChat.Unity;

[assembly: OwinStartup(typeof(WebChat.Startup))]
namespace WebChat
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();

            var httpConfiguration = new HttpConfiguration();
            WebApiConfig.Register(httpConfiguration);
            ConfigureUnityContainer(httpConfiguration);
            app.UseWebApi(httpConfiguration);
        }

        private void ConfigureUnityContainer(HttpConfiguration httpConfiguration)
        {
            var unityContainer = new UnityContainer();

            foreach (var type in GetTypesInheritingFrom<IUnityRegistry>())
            {
                var unityRegistry = (IUnityRegistry)unityContainer.Resolve(type);
                unityRegistry.Configure(unityContainer);
            }

            httpConfiguration.DependencyResolver = new UnityDependencyResolver(unityContainer);
        }

        private IEnumerable<Type> GetTypesInheritingFrom<TBase>()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                                .Where(assembly => assembly.FullName.StartsWith("WebChat"))
                                .SelectMany(assembly => assembly.GetTypes()
                                                                .Where(type => !type.IsAbstract && !type.IsInterface && typeof(TBase).IsAssignableFrom(type)));

            return types;
        }
    }
}