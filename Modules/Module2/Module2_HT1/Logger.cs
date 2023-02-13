using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HT1
{
    public enum LogType
    {
        Error,
        Info,
        Warning
    }

    internal class Logger : ILogger
    {
     
        static Logger instance;
        string singletonData = string.Empty;
        
        List< string> _messages=new List< string>();
        

        protected Logger()
        {
        }

        public static Logger Instance()
        {
            if (instance == null)
                instance = new Logger();

            return instance;
        }

        public void Log(LogType type, string message)
        {
            
            string logData = $"{DateTime.Now}: {type}:  {message}";
            Console.WriteLine(logData);
            _messages.Add(logData);

        }

        public void Error(string message)
        {
            Log(LogType.Error, message);

        }

        public void Info(string message)
        {
            Log(LogType.Info,message);
        }

        public void Warning(string message)
        {
            Log(LogType.Warning,message);
        }

        public void SaveLogToFile()
        {
            File.WriteAllLines("log.txt",_messages);
        }
    }
}