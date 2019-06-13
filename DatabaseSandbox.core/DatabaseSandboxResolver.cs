using System;
using System.Collections.Generic;
using DatabaseSandbox.Config;

namespace DatabaseSandbox.Core
{
    public static class DatabaseSandboxResolver
    {
        private static IResolver _resolver;
        static DatabaseSandboxResolver()
        {
        
        }

        public static void SetResolver(IResolver resolver)
        {
            if (_resolver == null)
                _resolver = resolver;
        }

        public static IResolver Current => _resolver;
    }
}
