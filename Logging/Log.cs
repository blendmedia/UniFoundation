using System.Collections.Generic;
using UnityEngine;

namespace UniFoundation.Logging
{
    public static class Log
    {
        private static readonly Dictionary<string, LogLevel> CategoryLogLevels = new Dictionary<string, LogLevel>();

        public static void SetStackTraceLevels()
        {
            Application.SetStackTraceLogType(LogType.Warning, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Log, StackTraceLogType.None);
        }
        
        public static void SetCategoryLogLevel(string logCategory, LogLevel logLevel)
        {
            CategoryLogLevels[logCategory] = logLevel;
        }
        
        public static void Output(string logCategory, string log, LogLevel logLevel = LogLevel.Info)
        {
            if ((CategoryLogLevels.ContainsKey(logCategory) == false) ||
                (CategoryLogLevels.ContainsKey(logCategory) && (logLevel >= CategoryLogLevels[logCategory])))
            {
                switch (logLevel)
                {
                    case LogLevel.Info:
                        Debug.Log($"{logCategory}: {log}");
                        break;
                    
                    case LogLevel.Warning:
                        Debug.LogWarning($"{logCategory}: {log}");
                        break;
                    
                    case LogLevel.Error:
                        Debug.LogError($"{logCategory}: {log}");
                        break;
                }
            }
        }
    }
}
