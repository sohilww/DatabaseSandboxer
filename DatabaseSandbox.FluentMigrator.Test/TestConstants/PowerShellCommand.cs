namespace DatabaseSandbox.FluentMigrator.Test.TestConstants
{
    internal static class PowerShellCommand
    {
        internal static string SuccessfulCommand = "$psVersionTable";
        internal static string WrongCommand = "get-services";
        internal static string PathOfPowerShellFile = @"TestConstants\testFile.ps1";
        internal static string DoesNotExistsFile = "MigratorFile/dosenotExists.txt";
    }
}