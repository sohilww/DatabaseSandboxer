using System;
using System.Collections.Generic;

namespace DatabaseSandbox.Core
{
    public static class DatabaseSandboxServiceLocator
    {
        static DatabaseSandboxServiceLocator()
        {
            _services = new Dictionary<Type, object>();
        }
        private static readonly Dictionary<Type, object> _services;
        public static TSuper GetService<TSuper>()
        {
            var instance = _services[typeof(TSuper)];
            return (TSuper)(instance);
        }

        public static void RegisterService<TSuper>(object implementation)
        {
            _services.Add(typeof(TSuper),implementation);
        }
    }
}
