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
            var res = new Result();


            for (int i = 0; i < 100; i++)
            {
                try
                {
                    int numberOfAction = new Random().Next(1, 4);
                    switch (numberOfAction)
                    {
                        case 1:
                        {
                            res = _action.LogInfoActionExample();

                            break;
                        }
                        case 2:
                        {
                            res = _action.LogWarningActionExample();


                            break;
                        }
                        case 3:
                        {
                            res = _action.LogErrorActionExample();

                            break;
                        }
                    }
                }
                catch (BusinessException e)
                {
                    Console.WriteLine(e);
                    _logger.Warning($"Action got this custom Exception: {e.Message}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    _logger.Error($"Action failed by reason: {e.Message}");
                }
                finally
                {
                    Console.WriteLine("finally");
                }
            }
        }
    }
}