using System;

namespace DatabaseSandbox.Core.Utility
{
    public static class DatabaseGenerator
    {
        public static string NewName => Guid.NewGuid().ToString("N");
    }
}