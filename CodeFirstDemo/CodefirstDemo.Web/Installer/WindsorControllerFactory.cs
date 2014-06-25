using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Castle.Windsor;

namespace CodefirstDemo.Web.Installer
{
    public class WindsorWebApiControllerFactory : IHttpControllerActivator
    {
        private readonly IWindsorContainer _container;

        public WindsorWebApiControllerFactory(IWindsorContainer container)
        {
            _container = container;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            return (IHttpController)_container.Resolve(controllerType);
        }
    }
}