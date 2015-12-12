using Owin;
using Microsoft.Owin;
using System.Web.Http;

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
            app.UseWebApi(httpConfiguration);
        }
    }
}