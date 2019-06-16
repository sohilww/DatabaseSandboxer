namespace DatabaseSandbox.Config
{
    public interface IDatabaseSandboxIOCModule
    {
        IServiceRegistry Registry();
    }

    public interface IDatabaseSandboxComponentModule
    {
        void Registry(IServiceRegistry serviceRegistry);
    }
}