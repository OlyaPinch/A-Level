using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HT1
{
    internal class Starter

    {
        private readonly IActions _action;
        private readonly ILogger _logger;

        public Starter(IActions action, ILogger logger)
        {
            _action = action;
            _logger = logger;
        }

        public void Run()
        {
            Result res = new Result();

            for (int i = 0; i < 100; i++)
            {
                
                int numberOfAction = new Random().Next(1,4 );
                switch (numberOfAction)
                {
                    case 1:
                    {
                       res= _action.FirstMethod();
                        
                        break;
                    }
                    case 2:
                    {
                        res=_action.SecondMethod();
                        
                        break;
                    }
                    case 3:
                    {
                       res= _action.ThirdMethod();
                      
                        break;
                    }
                }

                if (res.Status == false)
                {
                    _logger.Log(LogType.Error, $"Action faild by a reason: {res.Message}");
                }
            }
            _logger.SaveLogToFile();
        }
    }
}