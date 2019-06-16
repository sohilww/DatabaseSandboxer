using System.IO;
using System.Linq;
using System.Management.Automation;
using DatabaseSandbox.Core;
using DatabaseSandbox.Core.Exceptions;

namespace DatabaseSandbox.FluentMigrator
{
    public class PowerShellHandler :ICommandExecutor
    {
        public void Execute(string command)
        {
            using (var powerShell = PowerShell.Create())
            {
                powerShell.AddScript(command);
                powerShell.Invoke();
                if (powerShell.Streams.Error.Any())
                {
                    throw new CommandExecutorException(powerShell.Streams.Error.First().Exception.Message);
                }
            }
        }
        public void ExecuteFile(string commandPath)
        {
            if(!File.Exists(commandPath))
                throw new FileNotFoundException(commandPath);
            string command=File.ReadAllText(commandPath);
            Execute(command);
        }
    }
}