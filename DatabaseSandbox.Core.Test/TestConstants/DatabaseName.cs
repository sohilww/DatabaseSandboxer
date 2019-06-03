using System;

namespace DatabaseSandbox.Core.Test.TestConstants
{
    internal static class Database
    {
        internal static string TestName => Guid.NewGuid().ToString("N");
    }
}