using System;
using System.IO;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace Api.MEF
{
    public static class MEFConfigurion
    {   
        public static void Register(HttpConfiguration httpConfiguration)
        {
            var binPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin");

            var compositionContainer = MEFContainerFactory.Create(binPath);
            
            var controllerFactory = new MEFControllerFactory(
                compositionContainer,
                httpConfiguration.Services.GetHttpControllerActivator());

            httpConfiguration.Services.Replace(typeof(IHttpControllerActivator), controllerFactory);
        }
    }
}