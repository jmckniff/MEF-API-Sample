using System.Web.Http;
using Api;
using Api.MEF;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(StartUp))]
namespace Api
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            var httpConfiguration = new HttpConfiguration();

            MEFConfigurion.Register(httpConfiguration);
           
            SetupControllerRouting(httpConfiguration);
            RemoveApiXMLSupport(httpConfiguration);

            app.UseWebApi(httpConfiguration);
        }

        private void SetupControllerRouting(HttpConfiguration httpConfiguration)
        {
            httpConfiguration.MapHttpAttributeRoutes();
            httpConfiguration.Routes.MapHttpRoute(
                name: "Default",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private void RemoveApiXMLSupport(HttpConfiguration httpConfiguration)
        {
            var formatters = httpConfiguration.Formatters;
            formatters.Remove(formatters.XmlFormatter);
        }
    }
}