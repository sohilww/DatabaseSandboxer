using Autofac;

namespace DatabaseSandbox.Config.Autofac
{
    public class AutofacResolver:IResolver
    {
        private ILifetimeScope _container;

        public AutofacResolver(ILifetimeScope container)
        {
            _container = container;
        }
        public TService Resolve<TService>()
        {
            return _container.Resolve<TService>();
        }

        public void Dispose()
        {
            _container?.Dispose();
        }
    }
}