using System;
using System.IO;
using DatabaseSandbox.Core;
using DatabaseSandbox.Core.Exceptions;
using DatabaseSandbox.FluentMigrator.Test.TestConstants;
using FluentAssertions;
using Xunit;

namespace DatabaseSandbox.FluentMigrator.Test
{
    public class CommandExecutorTest
    {
        private ICommandExecutor _commandExecutor;
        public CommandExecutorTest()
        {
            _commandExecutor=new PowerShellHandler();
        }
        [Fact]
        public void when_send_command_should_execute_the_command()
        {
            var command = PowerShellCommand.SuccessfulCommand;
            var commandExecutor=new PowerShellHandler();

            commandExecutor.Execute(command);
        }
        [Fact]
        public void when_send_wrong_command_should_throw_CommandExecutorException()
        {
            var wrongCommand = PowerShellCommand.WrongCommand;
            
            Action action=()=> _commandExecutor.Execute(wrongCommand);

            action.Should().Throw<CommandExecutorException>();
        }
        [Fact]
        public void when_send_file_path_should_execute_the_command()
        {
            var comandPath = PowerShellCommand.PathOfPowerShellFile;

            Action action=()=> _commandExecutor.ExecuteFile(comandPath);

            action.Should().NotThrow<CommandExecutorException>();
        }

        [Fact]
        public void when_send_doesnot_exists_path_should_throw_FileNotFoundException()
        {
            var doesNotExistsFile = PowerShellCommand.DoesNotExistsFile;

            Action action=()=> _commandExecutor.ExecuteFile(doesNotExistsFile);

            action.Should().Throw<FileNotFoundException>();

        }
    }
}