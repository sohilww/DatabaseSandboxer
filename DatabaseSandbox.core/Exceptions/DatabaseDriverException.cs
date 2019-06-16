using System;

namespace DatabaseSandbox.Core.Exceptions
{
    public class DatabaseDriverException:DatabaseSandboxException
    {
        public DatabaseDriverException(string message) : base(message)
        {
        }

        public DatabaseDriverException(Exception exception)
            :this((exception.Message+exception.InnerException?.Message))
        {
        }
    }
}