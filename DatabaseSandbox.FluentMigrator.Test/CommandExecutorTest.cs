using System;
using DatabaseSandbox.Core.Exceptions;
using FluentAssertions;
using Xunit;

namespace DatabaseSandbox.FluentMigrator.Test
{
    public class CommandExecutorTest
    {
        [Fact]
        public void when_send_command_should_execute_the_command()
        {
            var command= "dotnet fm migrate -p sqlserver2012 -c \"data source =.; initial catalog = 2a56db347fe1463abfba920f336231eb; integrated security = true; \" -a \"F:\\Project\\PAP\\DatabaseSandboxer\\DatabaseSandbox.FluentMigrator.Test\\bin\\Debug\\netcoreapp2.2\\MigratorFile\\FluentMigrator.dll\"";
            var commandExecutor=new CommandExecutor();

            commandExecutor.Execute(command);
        }
        [Fact]
        public void when_send_wrong_command_should_throw_CommandExecutorException()
        {
            var wrongCommand = "use";
            var commandExecutor=new CommandExecutor();

            Action action=()=> commandExecutor.Execute(wrongCommand);

            action.Should().Throw<CommandExecutorException>();
        }
    }
}