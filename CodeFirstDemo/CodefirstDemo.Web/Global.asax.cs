using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CodeFirstDemo.Infrastructure.Data.Initialize;
using CodefirstDemo.Web.App_Start;
using Castle.Windsor;
using CodefirstDemo.Web.Installer;

namespace CodefirstDemo.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer _container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DatabaseInitialize.Initialize();
            WindsorBootstrapper.Initialze();
            _container = WindsorBootstrapper.GetContainer();
        }

        protected void Application_End()
        {
            _container.Dispose();
        }
    }
}