namespace Module3_6;

internal interface ILogger
{
    Task Log(LogType type, string message);
    public event Action<string> Backup;

    Task Error(string message);
    Task Info(string message);
    Task Warning(string message);
}