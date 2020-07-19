using System;
using System.IO;
using DbUp;
using DbUp.Helpers;
using DbUp.ScriptProviders;

namespace DbUpExample
{
    /*
     * DOCUMENTATION: https://dbup.readthedocs.io/en/latest/usage/
     *
     * SCRIPTS EXAMPLE:
     * 1. Create database: 000001-Create_Table_1 | naming_format {order-name}
     * 2. Insert table with data : 000001-Create_Table_2 | naming_format {order-name}
     * 3. Insert data to table : 000001-Insert_Data_In_Table_1 | naming_format {order-name}
     *
     * POWERSHELL COMMANDS:
     * 1. cd D:\Programming\Examples\DbUpExample\DbUpExample\bin\Debug\netcoreapp3.1
     * 2. dotnet DbUpExample.dll "Server=(localdb)\MSSQLLocalDB; Database=LD_TEST; Trusted_connection=true;" "D:\Programming\Examples\DbUpExample\DbUpExample\SQL_SCRIPTS"
     */

    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                return ReturnError(
                    "Invalid args. You have to specify connection string and scripts path.");
            }

            var connectionString = args[0];
            var scriptsPath = args[1];

            Console.WriteLine("STEP 1: Start executing predeployment scripts...");
            Console.WriteLine("Press Enter to continue...");

            Console.ReadKey(true);

            string preDeploymentScriptsPath = Path.Combine(scriptsPath, "PreDeployment");
            var preDeploymentScriptsExecutor = DeployChanges
                .To
                .SqlDatabase(connectionString)
                .WithScriptsFromFileSystem(preDeploymentScriptsPath, new FileSystemScriptOptions
                {
                    IncludeSubDirectories = true
                })
                .LogToConsole()
                .JournalToSqlTable("dbo", "SchemaVersions")
                .Build();

            var preDeploymentUpgradeResult = preDeploymentScriptsExecutor.PerformUpgrade();

            if (!preDeploymentUpgradeResult.Successful)
            {
                return ReturnError(preDeploymentUpgradeResult.Error.ToString());
            }

            ShowSuccess();

            Console.WriteLine("STEP 2:Start executing migration scripts...");
            Console.WriteLine("Press Enter to continue...");

            Console.ReadKey(true);

            var migrationScriptsPath = Path.Combine(scriptsPath, "Migrations");
            var upgrader = DeployChanges
                .To
                .SqlDatabase(connectionString)
                .WithScriptsFromFileSystem(migrationScriptsPath, new FileSystemScriptOptions
                {
                    IncludeSubDirectories = true

                })
                .LogToConsole()
                .JournalToSqlTable("dbo", "SchemaVersions")
                .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                return ReturnError(result.Error.ToString());
            }

            ShowSuccess();

            return 0;
        }

        private static void ShowSuccess()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
        }

        private static int ReturnError(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ResetColor();
            return -1;
        }
    }
}
