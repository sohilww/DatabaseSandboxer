namespace DatabaseSandbox.Core.Database
{
    public interface IDatabaseDriver
    {
        void ExecuteCommand(string command);
    }
}