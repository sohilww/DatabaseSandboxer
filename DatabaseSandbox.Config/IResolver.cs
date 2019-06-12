using System;

namespace DatabaseSandbox.Config
{
    public interface IResolver:IDisposable
    {
        TService Resolve<TService>();
    }
}