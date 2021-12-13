using System;

namespace DashboardTool.Common.Exceptions
{
    public class EnvironmentException : Exception
    {
        public EnvironmentException(string message): base(message)
        {
        }
    }
}