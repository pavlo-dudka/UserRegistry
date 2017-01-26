using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Practices.Unity.WebApi;
using Owin;
using UserRegistry.Core;

[assembly: OwinStartup(typeof(UserRegistry.WebApi.Startup))]

namespace UserRegistry.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            //GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            var resolver = new UnityDependencyResolver(UnityConfig.GetConfiguredContainer());
            config.DependencyResolver = resolver;

            app.UseWebApi(config);
        }
    }
}
