
namespace DatabaseSandbox.Config
{
    public interface IServiceRegistry
    {
        void Register<TService, TImplementation>() where TImplementation : TService;
        void RegisterSingleton<TService, TImplementation>() where TImplementation : TService;
    }
}
