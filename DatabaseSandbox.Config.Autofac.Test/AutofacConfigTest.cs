using Autofac;
using FluentAssertions;
using Xunit;

namespace DatabaseSandbox.Config.Autofac.Test
{
    public class AutofacConfigTest
    {
        [Fact]
        public void when_register_service_can_resolve_service()
        {
            var container = new ContainerBuilder();
            var serviceRegistry = container.CreateServiceRegistry();

            serviceRegistry.Register<IServiceTest, ServiceTest>();
            var resolver = container.CreateResolver();

            var service = resolver.Resolve<IServiceTest>();

            service.Should().NotBeNull();

            resolver.Dispose();
        }
        
        
    }
}
