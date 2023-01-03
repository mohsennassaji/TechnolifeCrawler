using Application.Services;
using Domain.SystemEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class LogManagmentService : ILogManagmentService
    {
        private readonly IDatabaseService _databaseService;

        public LogManagmentService(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public void Log(string message, object classObject, MethodBase? methodBase, string? group = null)
        {
            SaveLog(message, classObject?.GetType()?.Name, methodBase?.Name, string.Empty, DateTime.Now, group);
        }

        public void Log(Exception exception, object classObject, MethodBase? methodBase, string? group = null)
        {
            if (exception == null)
            {
                return;
            }

            SaveLog(exception.GetBaseException().Message, classObject?.GetType()?.Name, methodBase?.Name, exception.StackTrace, DateTime.Now, group);
        }

        private void SaveLog(string message, string? className, string? methodName, string? stackTrace, DateTime dateTime, string? group)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            if (message.Length > 2040)
            {
                message = message.Substring(0, 2040);
            }

            var log = new LogManagment()
            {
                Message = message,
                CreateDate = dateTime,
                GroupName = group,
                ClassName = className,
                MethodName = methodName,
                StackTrace = stackTrace
            };

            _databaseService.LogManagments.Add(log);
            _ = _databaseService.SaveChangesAsync(CancellationToken.None).Result;

            return;
        }
    }
}
