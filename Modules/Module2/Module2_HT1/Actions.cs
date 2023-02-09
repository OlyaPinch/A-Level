using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HT1
{
    internal interface IActions
    {
        Result FirstMethod();
        Result SecondMethod();
        Result ThirdMethod();
    }

    internal class Actions : IActions
    {
        private readonly ILogger _logger;


        public Actions(ILogger logger)
        {
            _logger = logger;
        }

        public Result FirstMethod()

        {
            Result info = new Result();
            info.Message = $"Start method:{nameof(FirstMethod)}";
            info.Status = true;
            _logger.Info(info.Message);
            return info;
        }

        public Result SecondMethod()
        {
            Result warning = new Result();
            warning.Status = true;
            warning.Message = $"Skipped logic in method:{nameof(SecondMethod)}";
            _logger.Warning(warning.Message);
            return warning;
        }

        public Result ThirdMethod()
        {
            Result error = new Result();
            error.Message = "I broke a logic";
            error.Status = false;
            _logger.Error(error.Message);
            return error;
        }
    }
}