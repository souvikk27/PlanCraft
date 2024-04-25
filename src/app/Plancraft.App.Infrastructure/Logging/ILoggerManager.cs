namespace Plancraft.App.Infrastructure.Logging;

public interface ILoggerManager
{
    void LogInfo(string message);
    void LogError(string message);
    void LogException(Exception exception);
    void LogError(string message, Exception exception);
    void LogWarning(string message);
    void LogDebug(string message);
}