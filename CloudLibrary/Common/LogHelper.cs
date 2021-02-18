using System;
using System.ComponentModel;

namespace CloudLibrary.Common
{
    public class LogHelper
    {
        public static void Log(string message, bool addEmptyLine = true)
        {
            Console.WriteLine(message);
            if (addEmptyLine)
                Console.WriteLine();
        }
    }
}
