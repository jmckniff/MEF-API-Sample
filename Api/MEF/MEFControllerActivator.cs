using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Routing;

namespace Api.MEF
{
    public class MEFControllerFactory :
        DefaultControllerFactory,
        IHttpControllerActivator
    {
        private readonly CompositionContainer _container;
        private readonly IHttpControllerActivator _internalActivator;

        public MEFControllerFactory(
            CompositionContainer container,
            IHttpControllerActivator internalActivator)
        {
            _container = container;
            _internalActivator = internalActivator;
        }

        public override IController CreateController(
            RequestContext requestContext,
            string controllerName)
        {
            var controller =
                base.CreateController(requestContext, controllerName);
            _container.SatisfyImportsOnce(controller); // MEF injection
            return controller;
        }

        public IHttpController Create(
            HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            var controller = _internalActivator.Create(request, controllerDescriptor, controllerType);
            _container.SatisfyImportsOnce(controller); // MEF injection
            return controller;
        }
    }
}