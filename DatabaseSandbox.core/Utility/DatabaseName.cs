using System;

namespace DatabaseSandbox.core.Utility
{
    public static class Database
    {
        public static string Name => Guid.NewGuid().ToString("N");
    }
}