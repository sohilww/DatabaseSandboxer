using System.Diagnostics;
using System.Linq;
using DatabaseSandbox.Core;

namespace DatabaseSandbox.FluentMigrator
{
    public class CommandExecutor :ICommandExecutor
    {
        public void Execute(string command)
        {
            //because power shell sdk make the framework use .net core
            //for now i am using cmd (I know it's not cross platform)
            //but i will back and fix that later
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
                process.ErrorDataReceived += Process_ErrorDataReceived;
                process.OutputDataReceived += Process_OutputDataReceived;
                process.Start();

                process.Exited += Process_Exited;
            }
        }

        private void Process_Exited(object sender, System.EventArgs e)
        {
            var p = (Process) sender;
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            
        }

        public void ExecuteFile(string commandPath)
        {
            throw new System.NotImplementedException();
        }
    }
}