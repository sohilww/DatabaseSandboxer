using System;

namespace DatabaseSandbox.Core.Exceptions
{
    public abstract class DatabaseSandboxException:Exception
    {
        public DatabaseSandboxException(string message):base(message)
        {
            
        }
    }
}