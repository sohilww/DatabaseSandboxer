
using System;

namespace DatabaseSandbox.Config
{
    public interface IServiceRegistry
    {
        void Register<TService, TImplementation>() where TImplementation : TService;
        void Register<TImplementation>();
        void Register(Type service, Type implementation);
        void Register<TService>(object implementation);
        void RegisterSingleton<TService, TImplementation>() where TImplementation : TService;
    }
}
