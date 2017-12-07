using System;
using System.Collections.Generic;

namespace ShuffleConsoleApp
{
    // Want to avoid direct calls to Console writeline but don't need anything to elaborate either
    public class SimpleLogger
    {
        public static List<string> logStatements = new List<string>();

        public SimpleLogger()
        {
        }
        public void Log(string logString)
        {
            logStatements.Add(logString);
            Console.WriteLine(logString);
        }
    }
}
