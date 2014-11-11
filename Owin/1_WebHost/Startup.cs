using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(_1_WebHost.Startup))]

namespace _1_WebHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Run(context =>
            {
                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("Hello, world.");
            });
        }
    }
}
