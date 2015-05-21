using System;
using System.IO;

namespace Shong.Engine
{
    enum LogType
    {
        Info,
        Warning,
        Error
    }

    class Log
    {
        private static          Log    _instance  = null;
        private static readonly object Padlock    = new object();
        public bool                    ConsoleOut = true;
        public string                  FilePath   = null;

        Log()
        {
        }

        public static Log Instance
        {
            get
            {
                lock (Padlock)
                {
                    return _instance ?? (_instance = new Log());
                }
            }
        }

        public void LogMsg(LogType type, string logMsg)
        {
            if (FilePath != null)
            {
                using (var stream = new StreamWriter(FilePath, true))
                {
                    stream.WriteLine("{0}\t{1}\t{2}", type, DateTime.Now, logMsg);
                }
            }
            else
            {
                // Attempting to use the log before log file is set
                LogCon(LogType.Error, "Log file not set!");
            }

            if (ConsoleOut) LogCon(type, logMsg);
        }

        public void LogCon(LogType type, string logMsg)
        {
            Console.WriteLine("{0}\t{1}\t{2}", 
                type,
                DateTime.Now,
                logMsg);
        }
    }
}
