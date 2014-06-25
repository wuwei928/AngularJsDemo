using CodeFirstDemo.Infrastructure.Data;
using Castle.Windsor;

namespace CodeFirstDemo.Repostory
{
    public interface IDbContextProvider
    {
        CodeFirstDBContext GetCodeFirstDBContext();
    }

    public class DbContextProvider : IDbContextProvider
    {
        private readonly IWindsorContainer _container;

        public DbContextProvider(IWindsorContainer container)
        {
            _container = container;
        }

        public CodeFirstDBContext GetCodeFirstDBContext()
        {
          return  _container.Resolve<CodeFirstDBContext>();
        }
    }
}