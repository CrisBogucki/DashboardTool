using System.Reflection;
using DashboardTool.Infrastructure.Repository;
using Microsoft.Extensions.Hosting;

namespace DashboardTool.WidgetService.Repository.Migration
{
    public abstract class MigrateDatabaseWidgetService
    {
    }

    public static class MigrateDatabaseExtension
    {
        public static IHost MigrateDatabaseWidgetService(this IHost host)
        {
            return host.MigrateDatabaseBaseExtension<MigrateDatabaseWidgetService>(Assembly.GetExecutingAssembly());
        }
    }
}