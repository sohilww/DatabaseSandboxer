using System;
using System.IO;
using System.Linq;
using System.Management.Automation;
using DatabaseSandbox.core.Exceptions;

namespace DatabaseSandbox.core
{
    public class PowerShellHandler
    {
        public void Execute(string command)
        {
            if (IsScriptFile(command))
                command = RetrieveCommandByReadingTheFile(command);
            ExecuteCommand(command);

        }

        private static bool IsScriptFile(string command)
        {
            return File.Exists(command);
        }

        private string RetrieveCommandByReadingTheFile(string command)
        {
            return File.ReadAllText(command);
        }

        private void ExecuteCommand(string command)
        {
            using (var powerShell = PowerShell.Create())
            {
                powerShell.AddScript(command);
                powerShell.Invoke();
                if (powerShell.Streams.Error.Any())
                {
                    throw new PowerShellExecutingException();
                }
            }
        }
    }
}