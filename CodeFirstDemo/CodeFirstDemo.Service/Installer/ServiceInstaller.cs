using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using CodeFirstDemo.IService;

namespace CodeFirstDemo.Service.Installer
{
    public class ServiceInstaller:IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUserService>().ImplementedBy<UserService>().LifestyleSingleton());
        }
    }
}
