using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebChat.OwinMiddlewares
{
    public class SPAUrlRewritingMiddleware : OwinMiddleware
    {
        public SPAUrlRewritingMiddleware(OwinMiddleware next)
        : base(next)
        {
        }

        public override Task Invoke(IOwinContext context)
        {
            if (string.IsNullOrEmpty(Path.GetExtension(context.Request.Path.Value)))
            {
                context.Request.Path = new PathString("/");
            }

            return Next.Invoke(context);
        }
    }
}