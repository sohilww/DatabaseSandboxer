using System.Diagnostics;
using System.Net;
using DatabaseSandbox.Core;
//because power shell sdk force me to set use .net core
//for now i am using cmd (I know it's not cross platform)
//but i will back and fix that later
namespace DatabaseSandbox.FluentMigrator
{
    public class CommandExecutor :ICommandExecutor
    {
        public void Execute(string command)
        {
           
            using (Process process = new Process())
            {
                var startInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    Arguments = command
                };
                process.StartInfo = startInfo;
                process.Start();
            }
        }
        public void ExecuteFile(string commandPath)
        {
            var command = System.IO.File.ReadAllText(commandPath);
            Execute(command);
        }
    }
}