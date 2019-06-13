﻿using DatabaseSandbox.Config;
using DatabaseSandbox.Core;

namespace DatabaseSandbox.FluentMigrator
{
    public class FluentMigratorConfig: IDatabaseSandboxComponentModule
    {
        public void Registry(IServiceRegistry serviceRegistry)
        {
            serviceRegistry
                .Register<FluentMigratorConfiguration>();
            serviceRegistry.
                Register(typeof(IDatabaseSandboxHandler),
                    typeof(FluentMigratorHandler));

            serviceRegistry.Register<ICommandExecutor,CommandExecutor>();
        }

        public static void AddToIOC(IServiceRegistry serviceRegistry)
        {
            var f=new FluentMigratorConfig();
            f.Registry(serviceRegistry);
        }
    }
}