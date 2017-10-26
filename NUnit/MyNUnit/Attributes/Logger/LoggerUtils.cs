using System;

namespace Attributes.Logger
{
    public class LoggerUtils
    {
        public static void PrintIgnoreInfo(string nameMethod, bool info)
        {
            PrintNameMethod(nameMethod);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" IGNORE ");
            ResetColorAndWriteNewLine();
        }

        public static void PrintSuccess(string nameMethod, string time)
        {
            PrintNameMethod(nameMethod);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" SUCCESS ");
            PrintTime(time);
            ResetColorAndWriteNewLine();
        }

        public static void PrintFail(string nameMethod, string time, string messange)
        {
            PrintNameMethod(nameMethod);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" FAIL ");
            PrintTime(time);
            Console.ResetColor();
            Console.Write(@" Messange: {0}", messange);
            Console.WriteLine();
        }

        public static void PrintWarningNotTestMethod(string nameMethod, string messenge)
        {
            Console.WriteLine(@"WARNING run NOT TEST method: {0} AND GET EXCEPTION {1}", nameMethod, messenge);
        }

        public static void PrintWarning(string nameMethod, string messange)
        {
            Console.WriteLine(@"WARNING run method: {0} AND GET EXCEPTION {1}", nameMethod, messange);
        }

        private static void PrintNameMethod(string nameMethod)
        {
            Console.Write("Test: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(nameMethod + " ");
            Console.ResetColor();
        }

        private static void PrintTime(string time)
        {
            Console.Write(" TIME: {0}ms ", time);
        }

        private static void ResetColorAndWriteNewLine() 
        {
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}

