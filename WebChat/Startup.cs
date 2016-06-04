using Owin;
using Microsoft.Owin;
using System.Web.Http;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using WebChat.Unity;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.StaticFiles;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.Extensions;
using System.IO;
using WebChat.Configuration;
using System.Web;
using WebChat.OwinMiddlewares;
using Microsoft.Owin.Security.Cookies;
using System.Security.Claims;
using WebChat.Authentication;

[assembly: OwinStartup(typeof(WebChat.Startup))]
namespace WebChat
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies",
                Provider = new CookieAuthenticationProvider
                {
                    OnApplyRedirect = ctx =>
                    {
                        if (!IsAjaxRequest(ctx.Request))
                        {
                            ctx.Response.Redirect(ctx.RedirectUri);
                        }
                    }
                }
            });

            ClaimsPrincipal.PrimaryIdentitySelector = (ids) =>
            {
                ChatUserIdentity chatUserIdentity = null;
                var defaultPrimaryIdentity = ids.FirstOrDefault();
                if (defaultPrimaryIdentity != null)
                {
                    chatUserIdentity = new ChatUserIdentity(defaultPrimaryIdentity);
                }

                return chatUserIdentity;
            };

            var hubConfiguration = new HubConfiguration();
            var httpConfiguration = new HttpConfiguration();
            ConfigureUnityContainer(httpConfiguration, hubConfiguration);

            app.MapSignalR(hubConfiguration);
            GlobalHost.HubPipeline.RequireAuthentication();
            WebApiConfig.Register(httpConfiguration);

            app.UseWebApi(httpConfiguration);

            app.Use<SPAUrlRewritingMiddleware>();
            app.UseFileServer(new FileServerOptions()
            {
                FileSystem = new PhysicalFileSystem(Path.Combine(HttpRuntime.AppDomainAppPath, AppConstants.webAppPath)),
                RequestPath = new PathString(string.Empty)
            });
        }

        private static bool IsAjaxRequest(IOwinRequest request)
        {
            IReadableStringCollection query = request.Query;
            if ((query != null) && (query["X-Requested-With"] == "XMLHttpRequest"))
            {
                return true;
            }
            IHeaderDictionary headers = request.Headers;
            return ((headers != null) && (headers["X-Requested-With"] == "XMLHttpRequest"));
        }

        private void ConfigureUnityContainer(HttpConfiguration httpConfiguration, HubConfiguration hubConfiguration)
        {
            var unityContainer = new UnityContainer();

            foreach (var type in GetTypesInheritingFrom<IUnityRegistry>())
            {
                var unityRegistry = (IUnityRegistry)unityContainer.Resolve(type);
                unityRegistry.Configure(unityContainer);
            }

            unityContainer.RegisterType<IUserIdProvider, ClaimsUserIdProvider>();
            httpConfiguration.DependencyResolver = new UnityDependencyResolver(unityContainer);
            hubConfiguration.Resolver = new HubUnityDependencyResolver(unityContainer);
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