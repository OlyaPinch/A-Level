namespace Module2_HT1;

internal interface ILogger
{
    void Log(LogType type, string message);
    void SaveLogToFile();
    void Error(string message);
    void Info(string message);
    void Warning(string message);
}