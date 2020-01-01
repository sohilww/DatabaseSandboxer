using System;

namespace DatabaseSandbox.Core.Exceptions
{
    public class CannotConnectToDatabaseException : DatabaseSandboxException
    {
        public CannotConnectToDatabaseException(string message):base(message)
        {
            
        }

        public CannotConnectToDatabaseException(Exception exception)
            : this((exception.Message + exception.InnerException?.Message))
        {
        }
    }
}