using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192
{
    public class Logger
    {
        private static readonly ILog eventLog = LogManager.GetLogger("FileAppender1");
        private static readonly ILog errorLog = LogManager.GetLogger("FileAppender2");

        private static Logger instance = null;

        public static Logger GetInstance()
        {
            if (instance == null)
            {
                instance = new Logger();
            }
            return instance;
        }

        public void WriteToEventLog(string message)
        {
            eventLog.Info(message);
        }

        public void WriteToErrorLog(string message)
        {
            errorLog.Error(message);
        }
    }
}
