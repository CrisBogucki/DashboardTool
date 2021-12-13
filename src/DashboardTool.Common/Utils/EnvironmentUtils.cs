using System;
using DashboardTool.Common.Exceptions;

namespace DashboardTool.Common.Utils
{
    public static class EnvironmentUtils
    {
        public static string GetVariableValue(string variable)
        {
            return Environment.GetEnvironmentVariable(variable) ?? throw new EnvironmentException($"The defined variable {variable} does not exist in the current environment");
        }
    }
}