using System.Web;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Lifestyle;

namespace CodeFirstDemo.Repostory.Installer
{
    public class PerRequestLifeStyleManager : ILifestyleManager
    {
        readonly ILifestyleManager _perWebRequestLifestyleManager;
        readonly ILifestyleManager _perThreadLifestyleManager;

        public PerRequestLifeStyleManager()
        {
            _perWebRequestLifestyleManager = new ScopedLifestyleManager(new WebRequestScopeAccessor());
            _perThreadLifestyleManager = new ScopedLifestyleManager(new ThreadScopeAccessor());
        }

        public void Init(IComponentActivator componentActivator, IKernel kernel, ComponentModel model)
        {
            _perWebRequestLifestyleManager.Init(componentActivator, kernel, model);
            _perThreadLifestyleManager.Init(componentActivator, kernel, model);
        }

        public bool Release(object instance)
        {
            return GetManager().Release(instance);
        }

        public object Resolve(CreationContext context, IReleasePolicy releasePolicy)
        {
            return GetManager().Resolve(context, releasePolicy);
        }

        public void Dispose()
        {
            GetManager().Dispose();
        }

        ILifestyleManager GetManager()
        {
            if (HttpContext.Current != null)
            {
                return _perWebRequestLifestyleManager;
            }

            return _perThreadLifestyleManager;
        }
    }
}
