using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_6
{
    internal interface IActions
    {
        Result LogInfoActionExample();
        Result LogWarningActionExample();
        Result LogErrorActionExample();
    }

    internal class Actions : IActions
    {
        private readonly ILogger _logger;


        public Actions(ILogger logger)
        {
            _logger = logger;
        }

        public Result LogInfoActionExample()

        {
            Result info = new Result();
            info.Message = $"Start method:{nameof(LogInfoActionExample)}";
            info.Status = true;
            _logger.Info(info.Message);
            return info;
        }

        public Result LogWarningActionExample()
        {
            var Message = $"Skipped logic in method:{nameof(LogWarningActionExample)}";
            _logger.Warning(Message);
            throw new BusinessException(Message);
        }

        public Result LogErrorActionExample()
        {
            var Message = "I broke a logic";

            _logger.Error(Message);
            throw new Exception(Message);
        }
    }
}