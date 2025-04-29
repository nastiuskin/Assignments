using Assignment_11.Contracts;
using Assignment_11.Enums;

namespace Assignment_11
{
    public class FileLogger : ILogger
    {
        private readonly string _logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
        public async Task LogAsync(string methodName, string action, LogType logType)
        {
            Directory.CreateDirectory(_logDirectory);
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string filePath = Path.Combine(_logDirectory, $"Logs_{date}.log");

            string timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");

            string message = $"[{timeStamp}] [{logType}] Method: {methodName}, Action: {action}\n";

            using (var fileWriter = new StreamWriter(filePath, append: true))
            {
                await fileWriter.WriteLineAsync(message);
            }
        }
    }
}
