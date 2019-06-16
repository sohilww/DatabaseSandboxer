namespace DatabaseSandbox.Core
{
    public interface ICommandExecutor
    {
        void Execute(string command);
        void ExecuteFile(string commandPath);
    }
}