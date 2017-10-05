using System;

namespace MyUnit.Logger
{
    public class LoggerUtils
    {
        public static void PrintNameMethod (string nameMethod)
        {
            Console.Write (@"Test: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write (nameMethod + " ");
            Console.ResetColor ();
        }

        public static void ResetColorAndNewLine ()
        {
            Console.ResetColor ();
            Console.WriteLine ();
        }

        public static void PrintIgnoreInfo (string nameMethod, string info)
        {
            PrintNameMethod (nameMethod);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write (@" IGNORE ");
            Console.ResetColor ();
            Console.Write (@" INFO: {0} ", info);
            ResetColorAndNewLine ();
        }

        public static void PrintTime (string time)
        {
            string outFormat = " TIME: {0}ms ";
            Console.Write (@outFormat, time);
        }

        public static void PrintSuccess (string nameMethod, string time)
        {
            string outFormat = " SUCCESS ";
            PrintNameMethod (nameMethod);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write (outFormat);
            PrintTime (time);
            ResetColorAndNewLine ();
        }

        public static void PrintFail (string nameMethod, string time, string messange)
        {
            PrintNameMethod (nameMethod);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write (@" FAIL ");
            PrintTime (time);
            Console.ResetColor ();
            Console.Write (@" Messange: " + messange);
            ResetColorAndNewLine ();
        }
    }
}

