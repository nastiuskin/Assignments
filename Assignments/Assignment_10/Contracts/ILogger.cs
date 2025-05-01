using Assignment_11.Enums;

namespace Assignment_11.Contracts
{
    public interface ILogger
    {
        Task LogAsync(string methodName, string message, LogType logType);
    }
}
