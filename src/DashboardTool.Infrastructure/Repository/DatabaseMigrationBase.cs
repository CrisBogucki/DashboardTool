using System.Reflection;
using Autofac;
using DashboardTool.Common.Utils;
using DbUp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DashboardTool.Infrastructure.Repository
{
    public static class DatabaseMigrationBase
    {
        public static IHost MigrateDatabaseBaseExtension<T>(this IHost host, Assembly assembly)
        {
            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;

            var logger = services.GetRequiredService<ILogger<T>>();

            logger.LogInformation($"Database migration from service {assembly.GetName()}");

            string connection = EnvironmentUtils.GetVariableValue("CONNECTION_STRING");

            EnsureDatabase.For.SqlDatabase(connection);

            var upgrade = DeployChanges.To
                .SqlDatabase(connection)
                .WithScriptsEmbeddedInAssembly(assembly)
                .LogToConsole()
                .Build();

            var result = upgrade.PerformUpgrade();

            if (!result.Successful)
            {
                logger.LogError(result.Error, "An error occurred while migrating the database");
                return host;
            }

            logger.LogInformation("Database migrated ");

            return host;
        }
    }
}