using System;
using DatabaseSandbox.core;
using DatabaseSandbox.core.Exceptions;
using DatabaseSandbox.Core.Test.TestConstants;
using FluentAssertions;
using Xunit;

namespace DatabaseSandbox.Core.Test
{
    public class PowerShellHandlerTest
    {
        private readonly PowerShellHandler _powerShellHandler;

        public PowerShellHandlerTest()
        {
            _powerShellHandler = new PowerShellHandler();
        }
        [Fact]
        public void given_correctCommand_when_execute_then_shouldNot_throw_any_exception()
        {
            Action action = () => _powerShellHandler
                .Execute(PowerShellCommand.SuccessfulCommand,"dbName");

            action.Should().NotThrow<PowerShellExecutingException>();
        }

        [Fact]
        public void given_wrongCommand_when_execute_command_then_throw_exception()
        {
           
            Action action = () => _powerShellHandler
                .Execute(PowerShellCommand.WrongCommand,"dbName");

            action.Should().Throw<PowerShellExecutingException>();

        }

        [Fact]
        public void given_command_path_when_execute_command_then_should_not_throw_any_exception()
        {
            Action action = () => _powerShellHandler.Execute(PowerShellCommand.PathOfPowerShellFile,"dbName");

            action.Should().NotThrow<Exception>();
        }

    }
}