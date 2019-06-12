using Autofac;
using DatabaseSandbox.Config.Autofac.Test.Fakes;
using DatabaseSandbox.Core;
using DatabaseSandbox.FluentMigrator;
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

        [Fact]
        public void given_fluentMigratorConfig_when_add_config_to_autofac_then_resolve_fluentMigrator_Handler()
        {
            var containerBuilder=new ContainerBuilder();
            var serviceRegistry = containerBuilder.CreateServiceRegistry();

            FluentMigratorConfig.AddToIOC(serviceRegistry);
            var resolver = containerBuilder.CreateResolver();

            var handler = resolver.Resolve<IDatabaseSandboxHandler>();

            handler.Should().NotBeNull();
        }
    }
}
