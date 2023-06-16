using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingAssembly
{
    public class Logger
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public void Info(string message)
        {
            logger.Info(message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Error(Exception ex, string message)
        {
            logger.Error(ex, message);
        }
    }
}
