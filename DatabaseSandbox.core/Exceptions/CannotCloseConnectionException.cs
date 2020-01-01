using System;

namespace DatabaseSandbox.Core.Exceptions
{
    public class CannotCloseConnectionException : DatabaseSandboxException
    {
        public CannotCloseConnectionException(string message) : base(message)
        {

        }

        public CannotCloseConnectionException(Exception exception)
            : this((exception.Message + exception.InnerException?.Message))
        {
        }
    }
}