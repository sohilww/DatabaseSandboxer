using System;
using System.Collections.Generic;

namespace DatabaseSandbox.core
{
    public static class DatabaseSandboxServiceLocator
    {
        public static string ConnectionString = "";
        static DatabaseSandboxServiceLocator()
        {
            _services = new Dictionary<Type, Type>
            {
                {typeof(DatabaseCreation), typeof(SqlServerDatabase)}
            };
        }
        private static Dictionary<Type, Type> _services;
        public static T GetService<T>(object[] args=null)
        {
            var type = _services[typeof(T)];
            return (T)(Activator.CreateInstance(type,args));
        }
    }
}
