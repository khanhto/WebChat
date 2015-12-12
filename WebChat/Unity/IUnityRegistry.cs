using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebChat.Unity
{
    public interface IUnityRegistry
    {
        void Configure(IUnityContainer container);
    }
}