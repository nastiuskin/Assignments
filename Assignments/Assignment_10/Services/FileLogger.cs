using Assignment_11.Contracts;
using Assignment_11.Enums;

namespace Assignment_11
{
    public class FileLogger : ILogger
    {
        public async Task LogAsync(string methodName, string message, LogType logType)
        {
            string filePath = GetLogFilePath();
            string logMessage = GenerateLogMessage(methodName, message, logType);

            try
            {
                using (var fileWriter = new StreamWriter(filePath, append: true))
                {
                    await fileWriter.WriteLineAsync(logMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while logging: {ex.Message}");
            }
        }

        private string GetLogFilePath()
        {
            string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            Directory.CreateDirectory(logDirectory);

            string date = DateTime.Now.ToString("yyyy-MM-dd");
            return Path.Combine(logDirectory, $"Logs_{date}.log");
        }

        private string GenerateLogMessage(string methodName, string message, LogType logType)
        {
            string timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return $"[{timeStamp}] [{logType}] Method: {methodName}, Message: {message}";
        }
    }
}
