using System.IO;
using DatabaseSandbox.Core.Exceptions;

namespace DatabaseSandbox.FluentMigrator
{
    public class PowerShellHandler
    {
        public void Execute(string command, string databaseName)
        {
            if (IsScriptFile(command))
                command = RetrieveCommandByReadingTheFile(command);


            //Todo:Added this for passing manual test
            command = command.Replace("{dbName}", databaseName);
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