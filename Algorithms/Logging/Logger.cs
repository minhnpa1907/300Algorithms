// Author: minhnpa1907
namespace Algorithms.Logging
{
    internal class Logger
    {
        public static void Logging(string message)
        {
            Console.WriteLine($"MINH-CONSOLE: {message}");
        }

        public static void LoggingStart(string func)
        {
            Console.WriteLine("\n---------------------------");
            Logging($"{func} - Start");
        }

        public static void LoggingStop(string func, string output)
        {
            Console.WriteLine($"{func}: {output}");
            Logging($"{func} - Stop");
            Console.WriteLine("---------------------------\n");
        }
    }
}
