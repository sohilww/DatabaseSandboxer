using Autofac;

namespace DatabaseSandbox.Config.Autofac
{
    public class DatabaseSandboxIocAutofacModule:IDatabaseSandboxIOCModule
    {
        private readonly ContainerBuilder _container;

        public DatabaseSandboxIocAutofacModule(ContainerBuilder container)
        {
            _container = container;
        }


        public IServiceRegistry Registry()
        {
            return new AutoFacServiceRegistry(_container);
        }

        
    }
}