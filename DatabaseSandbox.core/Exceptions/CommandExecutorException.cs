namespace DatabaseSandbox.Core.Exceptions
{
    public class CommandExecutorException :DatabaseSandboxException
    {
        public CommandExecutorException(string message) : base(message)
        {
        }
    }
}