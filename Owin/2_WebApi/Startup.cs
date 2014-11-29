using System.Web.Http;
using Microsoft.Owin;
using Owin;
using _2_WebApi;

[assembly: OwinStartup(typeof (Startup))]

namespace _2_WebApi {
    public class Startup {
        public void Configuration(IAppBuilder app) {
            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseWebApi(config);
        }
    }
}