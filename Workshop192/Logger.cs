using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192
{
    public class Logger
    {
        private string eventPath;
        private string errorPath;

        private static Logger instance = null;

        private Logger()
        {
            eventPath = "";
            errorPath = "";
        }

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
            if (eventPath == "")
                SetEventPath();
            using (StreamWriter streamWriter = new StreamWriter(eventPath, true))
            {
                streamWriter.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "  " + message);
            }
        }

        public void WriteToErrorLog(string message)
        {
            if (errorPath == "")
                SetErrorPath();
            using (StreamWriter streamWriter = new StreamWriter(errorPath, true))
            {
                streamWriter.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "  " + message);
            }
        }

        public void SetEventPath()
        {
            foreach (string str in AppDomain.CurrentDomain.BaseDirectory.Split('\\'))
            {
                eventPath += str + "\\";
                if (str.Equals("Workshop192"))
                    break;
            }
            eventPath += "Logs\\EventLog.txt";
        }

        public void SetErrorPath()
        {
            foreach (string str in AppDomain.CurrentDomain.BaseDirectory.Split('\\'))
            {
                errorPath += str + "\\";
                if (str.Equals("Workshop192"))
                    break;
            }
            errorPath += "Logs\\ErrorLog.txt";
        }
    }
}
