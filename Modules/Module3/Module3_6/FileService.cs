using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;
using File = System.IO.File;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Module3_6
{
    internal interface IFileService
    {
        Task Save(string messages, string fileName);
        Config Config { get; set; }

        Task Backup(string path);
    }

    internal class FileService : IFileService
    {
        readonly string _fileConfig = "config.txt";
        readonly string _backupFolder = "Backup";


        public FileService()
        {
            if (File.Exists(_fileConfig))
            {
                var readAllText = File.ReadAllText(_fileConfig);
                Config = string.IsNullOrEmpty(readAllText)
                    ? Config.DefConfig()
                    : JsonConvert.DeserializeObject<Config>(readAllText);
                if (!Directory.Exists(Config.DirectoryName))
                    Directory.CreateDirectory(Config.DirectoryName);
            }
        }

        public Config Config { get; set; } = Config.DefConfig();


        public async Task Save(string messages, string fileName)

        {
            await File.AppendAllLinesAsync(fileName,
                new List<string> { messages });
        }

        public async Task Backup(string fileName)
        {
            var text = await File.ReadAllTextAsync(fileName);

            string backupFilename = $"{_backupFolder}/{DateTime.Now:yyyy-MM-dd_HH-mm-ss-ms}{Guid.NewGuid()}.log";

            if (!Directory.Exists(_backupFolder))
                Directory.CreateDirectory(_backupFolder);
            await File.WriteAllTextAsync(backupFilename, text);

            Console.WriteLine("BackUp is done");
        }
    }
}