using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CodeFirstDemo.Infrastructure.Data;
using CodeFirstDemo.IRepostory;

namespace CodeFirstDemo.Repostory.Installer
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IDbContextProvider>().ImplementedBy<DbContextProvider>().LifestyleSingleton());
            container.Register(Component.For<CodeFirstDBContext>().LifestyleCustom<PerRequestLifeStyleManager>());
            container.Register(Component.For<IUserRespostory>().ImplementedBy<UserRespostory>().LifestyleSingleton());
        }
    }
}
