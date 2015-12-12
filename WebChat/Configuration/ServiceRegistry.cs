using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebChat.Repository;
using WebChat.Unity;

namespace WebChat.Configuration
{
    public class ServiceRegistry : IUnityRegistry
    {
        public void Configure(IUnityContainer container)
        {
            container.RegisterType<IUsersRepository, UsersRepository>();
        }
    }
}