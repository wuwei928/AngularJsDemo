using System.Web.Http;
using System.Web.Http.Dispatcher;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using CodeFirstDemo.Repostory.Installer;
using CodeFirstDemo.Service.Installer;

namespace CodefirstDemo.Web.Installer
{
    public class WindsorBootstrapper
    {
        private static IWindsorContainer _container;
        public static void Initialze()
        {
            _container=new WindsorContainer();
            _container.Install(FromAssembly.This(), 
                               FromAssembly.Containing<ServiceInstaller>(),
                               FromAssembly.Containing<RepositoryInstaller>());

            _container.Register(
                Component.For<IWindsorContainer>().Instance(_container).LifestyleSingleton(),
                Component.For<IHttpControllerActivator>().Instance(new WindsorWebApiControllerFactory(_container)));
            
            var config = GlobalConfiguration.Configuration;
            config.Services.Replace(typeof(IHttpControllerActivator), _container.Resolve<IHttpControllerActivator>());
        }

        public static IWindsorContainer GetContainer()
        {
            return _container;
        }
    }
}