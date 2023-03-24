using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Module3_6
{
    public enum LogType
    {
        Error,
        Info,
        Warning
    }

    internal class Logger : ILogger
    {
        private readonly IFileService _fileService;
        public event Action<string> Backup;
        private int _logCount;
        private string _fileName;


        public Logger(IFileService fileService)
        {
            _fileService = fileService;
            _logCount = 0;
           
            _fileName=Path.Combine(_fileService.Config.DirectoryName, $"{DateTime.Now:yyyy - MM - dd_HH - mm - ss}.txt");
        }

        public async Task Log(LogType type, string message)
        {
            var logData = $"{DateTime.Now}: {type}:  {message}";
            Console.WriteLine(logData);
            await _fileService.Save(logData, _fileName);
            _logCount++;
            if (_logCount % _fileService.Config.BackupNumber == 0)
            {
                Backup?.Invoke(_fileName);
            }
        }

        public Task Error(string message)
        {
            return Log(LogType.Error, message);
        }

        public Task Info(string message)
        {
            return Log(LogType.Info, message);
        }

        public Task Warning(string message)
        {
           return Log(LogType.Warning, message);
        }
    }
}