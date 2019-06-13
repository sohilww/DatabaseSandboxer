using System;
using Autofac;

namespace DatabaseSandbox.Config.Autofac
{
    public class AutoFacServiceRegistry: IServiceRegistry
    {
        private readonly ContainerBuilder _container;

        public AutoFacServiceRegistry(ContainerBuilder container)
        {
            _container = container;
        }
        public void Register<TService, TImplementation>() where TImplementation : TService
        {
            _container.RegisterType<TImplementation>().As<TService>()
                .InstancePerLifetimeScope();
        }

        public void Register<TImplementation>()
        {
            _container.RegisterType<TImplementation>()
                .InstancePerLifetimeScope();
        }

        public void Register(Type service, Type implementation)
        {
            _container.RegisterType(implementation).As(service)
                .InstancePerLifetimeScope();
        }

        public void Register<TService>(object implementation)
        {
            _container.RegisterInstance(implementation)
                .As<TService>();
        }

        public void RegisterSingleton<TService, TImplementation>() where TImplementation : TService
        {
            _container.RegisterType<TImplementation>().As<TService>()
                .SingleInstance();
        }
    }
}
