using System;
using System.Linq;
using System.Management.Automation;
using DatabaseSandbox.core.Exceptions;

namespace DatabaseSandbox.core
{
    public class PowerShellHandler
    {
        public void Execute(string command)
        {
            using (var powerShell=PowerShell.Create())
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