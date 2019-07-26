using System;
using System.IO;
using System.Linq;
using System.Management.Automation;
using DatabaseSandbox.Core;
using DatabaseSandbox.Core.Exceptions;

namespace DatabaseSandbox.FluentMigrator
{
    public class PowerShellHandler : ICommandExecutor
    {
        public void Execute(string command)
        {
            using (var powerShell = PowerShell.Create())
            {
                powerShell.AddScript(command);
                powerShell.Invoke();
                if (powerShell.Streams.Error.Any())
                {
                    var errorMessages = ReadErrorMessages(powerShell);
                    throw new CommandExecutorException(errorMessages);
                }
            }
        }

        private static string ReadErrorMessages(PowerShell powerShell)
        {
            var errors = powerShell.Streams.Error.Select(a => a.Exception.Message);
            var errorMessages = string.Join(Environment.NewLine, errors);
            return errorMessages;
        }

        public void ExecuteFile(string commandPath)
        {
            if (!File.Exists(commandPath))
                throw new FileNotFoundException(commandPath);
            string command = File.ReadAllText(commandPath);
            Execute(command);
        }
    }
}