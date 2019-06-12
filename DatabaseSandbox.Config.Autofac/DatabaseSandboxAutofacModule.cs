using Autofac;

namespace DatabaseSandbox.Config.Autofac
{
    public class DatabaseSandboxAutofacModule:IDatabaseSandboxModule
    {
        private readonly ContainerBuilder _container;

        public DatabaseSandboxAutofacModule(ContainerBuilder container)
        {
            _container = container;
        }


        public IServiceRegistry Registry()
        {
            return new AutoFacServiceRegistry(_container);
        }
    }
}