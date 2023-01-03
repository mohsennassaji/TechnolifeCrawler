using System.Reflection;

namespace Application.Services
{
    public interface ILogManagmentService
    {
        void Log(string message, object classObject, MethodBase? methodBase, string? group = null);
        void Log(Exception exception, object classObject, MethodBase? methodBase, string? group = null);
    }
}
