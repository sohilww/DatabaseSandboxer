using System;
using System.Reflection;
using Xunit.Sdk;

namespace DatabaseSandboxer.Xunit
{

    public class DatabaseSandbox : BeforeAfterTestAttribute
    {
        private readonly string _databaseName;

        public DatabaseSandbox(string databaseName)
        {
            _databaseName = databaseName;
        }

        public override void Before(MethodInfo methodUnderTest)
        {
            base.Before(methodUnderTest);
        }
    }
}
