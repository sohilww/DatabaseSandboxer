using System;

namespace DatabaseSandbox.Core.Exceptions
{
    public abstract class DatabaseSandboxException:Exception
    {
        protected DatabaseSandboxException(string message):base(message)
        {
            
        }
    }
}